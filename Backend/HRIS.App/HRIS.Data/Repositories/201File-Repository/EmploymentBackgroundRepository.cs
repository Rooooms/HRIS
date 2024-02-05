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
    public class EmploymentBackgroundRepository: IEmploymentBackgroundRepository
    {
        private readonly AppDbContext _context;

        public EmploymentBackgroundRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(EmploymentBackground newEducationalBg)
        {
            _context.EmploymentBackgrounds.Add(newEducationalBg);
        }

        public void Delete(EmploymentBackground EmploymentBg)
        {
            _context.EmploymentBackgrounds.Remove(EmploymentBg);
        }

        public Task<List<EmploymentBackground>> GetAll()
        {
            return _context.EmploymentBackgrounds.OrderBy(p => p.IncDate).ToListAsync();
        }

        public Task<EmploymentBackground?> GetById(Guid id)
        {
            return _context.EmploymentBackgrounds.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
