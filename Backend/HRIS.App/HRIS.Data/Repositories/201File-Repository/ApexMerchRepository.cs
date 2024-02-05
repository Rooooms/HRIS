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
    public class ApexMerchRepository : IApexMerchRepository
    {
        private readonly AppDbContext _context;

        public ApexMerchRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ApexMerch newApexMerch)
        {
            _context.ApexMerches.Add(newApexMerch);
        }

        public void Delete(ApexMerch ApexMerch)
        {
            _context.ApexMerches.Remove(ApexMerch);
        }

        public Task<List<ApexMerch>> GetAll()
        {
            return _context.ApexMerches.OrderBy(p => p.RamPercent).ToListAsync();
        }

        public Task<ApexMerch?> GetById(Guid id)
        {
            return _context.ApexMerches.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
