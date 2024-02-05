using HRIS.Core.Entities;
using HRIS.Core.Entities.Leave_Entities;
using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Repositories.Leaves_Repositories;
using HRIS.Core.Interfaces.Repositories.UserRepository;
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

        private readonly IUserService _userService;


        public LeaveService(IEmployeeDetailsRepository employee, AppDbContext context, ILeaveRepository leave, IUserRepository user, IUserService userService)
        {
            _leave = leave;
            _context = context;
            _employee = employee;
            _user= user;
            _userService = userService;
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
            Console.WriteLine("EmployeeID", employeeId);

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

            var leaveDto = leave.Adapt<LeaveResponse>();

            return leaveDto;
        }


        //public async Task<LeaveResponse> Update(Guid id, LeaveRequest request)
        //{
        //    var loggedUser = await _userService.CheckLogged();
        //    Guid userId = loggedUser.Id;

        //    var user = await _user.GetById(userId);

        //    if (user == null) return null;

        //    var employeeId = user.EmployeeId;

        //    var employeeDetails = await _employee.GetById(employeeId);
        //    if (employeeDetails == null) return null;

        //    var leave = await _leave.GetById(id);

        //    if (leave == null) return null;

        //    // Update leave fields based on the values in the request
        //    // Modify this section based on your actual fields and requirements
        //    leave.Status = request.Status;
        //    leave.Reason = request.Reason;
        //    leave.LeaveStartDate = request.LeaveStartDate;
        //    leave.LeaveEndDate = request.LeaveEndDate;

        //    // You may need additional logic here based on your requirements

        //    // Save changes to the database
        //    await _leave.SaveChangesAysnc();

        //    // Return the updated leave object
        //    var leaveDto = leave.Adapt<LeaveResponse>();
        //    return leaveDto;
        //}


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
