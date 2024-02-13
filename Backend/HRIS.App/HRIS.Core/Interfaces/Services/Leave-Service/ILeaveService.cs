using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Requests.Leave_Request;
using HRIS.Core.Models.Responses;
using HRIS.Core.Models.Responses.Leave_Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services.Leave_Service
{
    public interface ILeaveService
    {
        Task<List<LeaveResponse>> GetAll();

        Task<LeaveResponse?> GetById(Guid id);

        Task<List<LeaveResponse>> GetLeavesByEmployeeNumber(int employeeNumber);
        Task<List<LeaveResponse>> GetLeavesByDepartment(string department);
        Task<LeaveResponse> Create(HttpContext httpContext, LeaveRequest request);

        Task<LeaveResponse> Update(Guid id, LeaveRequest request);

        Task<bool> Delete(Guid id);
    }
}
