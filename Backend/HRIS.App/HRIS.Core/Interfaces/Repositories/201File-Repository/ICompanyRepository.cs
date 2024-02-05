using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAll();

        Task<Company?> GetById(Guid id);

        Task<List<Company>> GetBySearch(string search);
        
        Task<Company?> GetByCompany(string companyName);


        void Add(Company newCompany);

        void Delete(Company company);

        Task<int> SaveChangesAysnc();
    }
}
