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
    public class SalaryRepository :ISalaryRepository
    {
        private readonly AppDbContext _context;

        public SalaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Salary newSalary)
        {
            _context.Salaries.Add(newSalary);
        }

        public void Delete(Salary salary)
        {
            _context.Salaries.Remove(salary);
        }

        public Task<List<Salary>> GetAll()
        {
            return _context.Salaries.OrderBy(p => p.DailyRate).ToListAsync();
        }

        public Task<Salary?> GetById(Guid id)
        {
            return _context.Salaries.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
