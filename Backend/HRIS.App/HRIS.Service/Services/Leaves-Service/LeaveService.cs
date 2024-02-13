using HRIS.Core.Entities;
using HRIS.Core.Entities.Leave_Entities;
using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Repositories.Leaves_Repositories;
using HRIS.Core.Interfaces.Repositories.UserRepository;
using HRIS.Core.Interfaces.Services.EmailSender;
using HRIS.Core.Interfaces.Services.Leave_Service;
using HRIS.Core.Interfaces.Services.User_Service;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Requests.Leave_Request;
using HRIS.Core.Models.Responses;
using HRIS.Core.Models.Responses.Leave_Response;
using HRIS.Data;
using HRIS.Service.Services.User_Service;
using Mapster;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Service.Services.Leaves_Service
{
    public class LeaveService : ILeaveService
    {

        private readonly IEmployeeDetailsRepository _employee;
        public readonly ILeaveRepository _leave;
        public readonly AppDbContext _context;
        private readonly IUserRepository _user;
        private readonly IEmailService _emailService;

        private readonly IUserService _userService;


        public LeaveService(IEmployeeDetailsRepository employee,
                            AppDbContext context, ILeaveRepository leave,
                            IUserRepository user, 
                            IUserService userService, IEmailService emailService)
        {
            _leave = leave;
            _context = context;
            _employee = employee;
            _user = user;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<List<LeaveResponse>> GetAll()
        {
            var leave = await _leave.GetAll();
            var leaveDto = leave.Adapt<List<LeaveResponse>>();

            return leaveDto;
        }

        public async Task<LeaveResponse?> GetById(Guid id)
        {
            var leave = await _leave.GetById(id);


            var leaveDto = leave?.Adapt<LeaveResponse>();

            return leaveDto;
        }

        public async Task<List<LeaveResponse>> GetLeavesByEmployeeNumber(int employeeNumber)
        {
            var leaves = await _leave.GetLeavesByEmployeeNumber(employeeNumber);
            return leaves.Select(leave => leave.Adapt<LeaveResponse>()).ToList();
        }
        public async Task<List<LeaveResponse>> GetLeavesByDepartment(string department)
        {
            var leaves = await _leave.GetLeavesByDepartment(department);
            return leaves.Select(leave => leave.Adapt<LeaveResponse>()).ToList();
        }
        public async Task<LeaveResponse> Create(HttpContext httpContext, LeaveRequest request)
        {

            
            var employeeNumberClaim = httpContext.User.FindFirst(ClaimTypes.Name);


            if (employeeNumberClaim == null || string.IsNullOrEmpty(employeeNumberClaim.Value))
            {
                // Handle the case where the user claims are not valid.
                return null;
            }


            int employeeNumber = int.Parse(employeeNumberClaim.Value);

            // Use the employee number to get the user from the database
            var user = await _user.GetUserByEmpNumber(employeeNumber);

            if (user == null)
            {
                // Handle the case where the user is not found.
                return null;
            }

            var employeeId = user.EmployeeId;
            

            var employeeDetails = await _employee.GetById(employeeId);

            if (employeeDetails == null)
            {
                // Handle the case where employee details are not found.
                return null;
            }

            var leave = request.Adapt<LeaveEntities>();

            if (leave == null || leave.DateSubmitted == null ||
                leave.LastSubmissionMonth == null || leave.LastSubmissionYear == null)
            {
                // Handle the case where the adapted leave object or its properties are not valid.
                return null;
            }

            int currentMonth = leave.DateSubmitted.Month;
            int currentYear = leave.DateSubmitted.Year;

            leave.UserId = user.Id;
            leave.EmployeeId = employeeId;
            leave.EmployeeName = $"{employeeDetails.FName} {employeeDetails.LName}";
            leave.EmployeeNumber = user.EmployeeNumber;
            leave.UserLevel = employeeDetails.UserLevel;
            leave.Company = employeeDetails.CompanyName;
            leave.Branch = employeeDetails.Branch;
            leave.Department = employeeDetails.Department;
            leave.DateSubmitted = DateTime.UtcNow;
            leave.Status = "Requested";

            if (leave.UserLevel == 1 && currentMonth == leave.LastSubmissionMonth && currentYear == leave.LastSubmissionYear)
            {
                leave.Credit += 1.25;
            }
            else if (leave.UserLevel == 2 && currentMonth == leave.LastSubmissionMonth && currentYear == leave.LastSubmissionYear)
            {
                leave.Credit += 1.67;
            }
            else if (leave.UserLevel == 3 && currentMonth == leave.LastSubmissionMonth && currentYear == leave.LastSubmissionYear)
            {
                leave.Credit += 2.06;
            }
            else
            {
                leave.Credit = leave.UserLevel switch
                {
                    1 => 1.25,
                    2 => 1.67,
                    3 => 2.06,
                    _ => 1.25
                };

                leave.LastSubmissionMonth = currentMonth;
                leave.LastSubmissionYear = currentYear;
            }

            _leave.Add(leave);

            await _leave.SaveChangesAysnc();
            await SendLeaveRequestEmailToManager(leave);

            var leaveDto = leave.Adapt<LeaveResponse>();

            return leaveDto;
        }

        private async Task SendLeaveRequestEmailToManager(LeaveEntities leave)
        {
            var userType = "Manager";
            var manager = await _user.GetByUserType(userType);
            if (manager == null) return;

            if (manager.Department == leave.Department)
            {

                var managerDto = await _employee.GetByEmployee(manager.EmployeeNumber);
                if (managerDto == null) return;

                string emailBody = $@"<p>Leave request submitted by {leave.EmployeeName}</p>
                         <p>Date: {leave.LeaveStartDate}</p>
                         <p>Until: {leave.LeaveEndDate}</p>
                         <p>Reason: {leave.Reason}</p>
                         <p>Click <a href='http://localhost:4200/Dashboard/manageleave'>here</a> for more information.</p>";


                // Send email to manager
                await _emailService.SendEmailAsync(managerDto.Email, "Leave Request Notification", emailBody);
            }

            else return;
            
        }


        public async Task<LeaveResponse> Update(Guid id, LeaveRequest request)
        {

            

            var leave = await _leave.GetById(id);

            if (leave == null) return null;

            leave.LeaveStartDate = request.LeaveStartDate;
            leave.LeaveEndDate = request.LeaveEndDate;
            leave.ResOfCancel = request.ResOfCancel;
            leave.Reason = request.Reason;
            leave.Status = request.Status;
      
            // You may need additional logic here based on your requirements

            // Save changes to the database
            await _leave.SaveChangesAysnc();

            // Return the updated leave object
            var leaveDto = leave.Adapt<LeaveResponse>();
            return leaveDto;
        }


        public async Task<bool> Delete(Guid id)
        {
            var salary = await _leave.GetById(id);

            if (salary == null) return false;

            _leave.Delete(salary);

            await _leave.SaveChangesAysnc();

            return true;
        }

        
    }
}
