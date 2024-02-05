using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface ISalaryRepository
    {
        Task<List<Salary>> GetAll();

        Task<Salary?> GetById(Guid id);
        void Add(Salary newSalary);

        void Delete(Salary salary);

        Task<int> SaveChangesAysnc();
    }
}
