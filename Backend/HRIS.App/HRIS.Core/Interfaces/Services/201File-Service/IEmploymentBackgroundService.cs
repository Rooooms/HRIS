using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IEmploymentBackgroundService
    {
        Task<List<EmploymentBackgroundResponse>> GetAll();

        Task<EmploymentBackgroundResponse?> GetById(Guid id);

        Task<EmploymentBackgroundResponse> Create(Guid id, EmploymentBackgroundRequest request);

        Task<EmploymentBackgroundResponse> Update(Guid id, EmploymentBackgroundRequest request);

        Task<bool> Delete(Guid id);
    }
}
