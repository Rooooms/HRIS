using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface ISalaryService
    {
        Task<List<SalaryResponse>> GetAll();

        Task<SalaryResponse?> GetById(Guid id);

        Task<SalaryResponse> Create(Guid id, SalaryRequest request);

        Task<SalaryResponse> Update(Guid id, SalaryRequest request);

        Task<bool> Delete(Guid id);
    }
}
