using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IBenefitRepository
    {
        Task<List<Benefit>> GetAll();

        Task<Benefit?> GetById(Guid id);
        void Add(Benefit newBenefit);

        void Delete(Benefit benefit);

        Task<int> SaveChangesAysnc();
    }
}
