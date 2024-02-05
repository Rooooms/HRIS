using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IRequirementRepository
    {
        Task<List<Requirement>> GetAll();

        Task<Requirement?> GetById(Guid id);
        void Add(Requirement newRequirement);

        void Delete(Requirement requirement);

        Task<int> SaveChangesAysnc();
    }
}
