using HRIS.Core.Entities;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IBranchService
    {
        Task<List<BranchResponse>> GetAll();

        Task<BranchResponse?> GetById(Guid id);

        Task<List<BranchResponse>> GetBySearch(string search);

        Task<BranchResponse> Create(BranchRequest request);

        Task<BranchResponse> Update(Guid id, BranchRequest request);

        Task<bool> Delete(Guid id);
        Task<List<Branch>> GetBranchByCompanyId(Guid CompanyId);
    }
}
