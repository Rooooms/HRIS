using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IEmployeeDetailService
    {
        Task<List<EmployeeDetailsResponse>> GetAll();

        Task<EmployeeDetailsResponse?> GetById(Guid id);

        Task<List<EmployeeDetailsResponse>> GetBySearch(string search);

        Task<EmployeeDetailsResponse> Create(EmployeeDetailsRequest request);

        Task<EmployeeDetailsResponse> Update(Guid id, EmployeeDetailsRequest request);

        Task<bool> Delete(Guid id);
    }
}
