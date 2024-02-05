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
    public class BenefitRepository : IBenefitRepository
    {
        private readonly AppDbContext _context;

        public BenefitRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Benefit newBenefit)
        {
            _context.Benefits.Add(newBenefit);
        }

        public void Delete(Benefit Benefit)
        {
            _context.Benefits.Remove(Benefit);
        }

        public Task<List<Benefit>> GetAll()
        {
            return _context.Benefits.OrderBy(p => p.DateGiven).ToListAsync();
        }

        public Task<Benefit?> GetById(Guid id)
        {
            return _context.Benefits.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
