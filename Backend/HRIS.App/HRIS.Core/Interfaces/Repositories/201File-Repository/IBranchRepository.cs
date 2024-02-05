using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAll();

        Task<Branch?> GetById(Guid id);

        Task<List<Branch>> GetBySearch(string search);
        //Task<Company?> GetByCategory(string companyName);
        Task<List<Branch>> GetBranchByCompanyId(Guid CompanyId);
        Task<Branch?> GetByBranch(string branchLocation);

        void Add(Branch newBranch);

        void Delete(Branch branch);

        Task<int> SaveChangesAysnc();
    }
}
