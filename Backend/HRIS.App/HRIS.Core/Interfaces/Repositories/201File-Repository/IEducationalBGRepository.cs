using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IEducationalBGRepository
    {
        Task<List<EducationalBg>> GetAll();

        Task<EducationalBg?> GetById(Guid id);
        void Add(EducationalBg newEducationalBg);

        void Delete(EducationalBg educationalBg);

        Task<List<EducationalBg>> GetEducationalBgByEmployeeId(Guid employeeId);

        Task<int> SaveChangesAysnc();
    }
}
