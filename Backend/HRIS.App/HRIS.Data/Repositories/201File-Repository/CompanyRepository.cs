using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Company newCompany)
        {
            _context.Companies.Add(newCompany);
        }

        public void Delete(Company Company)
        {
            _context.Companies.Remove(Company);
        }

        public Task<List<Company>> GetAll()
        {
            return _context.Companies.OrderBy(p => p.CompanyName).ToListAsync();
        }

        public Task<Company?> GetById(Guid id)
        {
            return _context.Companies.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Company>> GetBySearch(string search)
        {
            return _context.Companies.Where(p => p.CompanyName.Contains(search)).ToListAsync();
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }

        public Task<Company?> GetByCompany(string companyName)
        {
            return _context.Companies.FirstOrDefaultAsync(p => p.CompanyName == companyName);
        }


    }
}
