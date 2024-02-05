using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyResponse>> GetAll();

        Task<CompanyResponse?> GetById(Guid id);

        Task<List<CompanyResponse>> GetBySearch(string search);

        Task<CompanyResponse> Create(CompanyRequest request);

        Task<CompanyResponse> Update(Guid id, CompanyRequest request);

        Task<bool> Delete(Guid id);
    }
}
