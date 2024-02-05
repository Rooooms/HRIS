using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IEmploymentBackgroundRepository
    {
        Task<List<EmploymentBackground>> GetAll();

        Task<EmploymentBackground?> GetById(Guid id);
        void Add(EmploymentBackground newEmploymentBg);

        void Delete(EmploymentBackground EmploymentBg);

        Task<int> SaveChangesAysnc();
    }
}
