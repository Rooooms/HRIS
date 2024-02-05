using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IPaymastRepository
    {
        Task<List<Paymast>> GetAll();

        Task<Paymast?> GetById(Guid id);
        void Add(Paymast newPaymast);

        void Delete(Paymast paymast);

        Task<int> SaveChangesAysnc();
    }
}
