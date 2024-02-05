using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IApexMerchRepository
    {
        Task<List<ApexMerch>> GetAll();

        Task<ApexMerch?> GetById(Guid id);
        void Add(ApexMerch newApexMerch);

        void Delete(ApexMerch ApexMerch);

        Task<int> SaveChangesAysnc();
    }
}
