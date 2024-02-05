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
    public class PaymastRepository : IPaymastRepository
    {
        private readonly AppDbContext _context;

        public PaymastRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Paymast newPaymast)
        {
            _context.Paymasts.Add(newPaymast);
        }

        public void Delete(Paymast paymast)
        {
            _context.Paymasts.Remove(paymast);
        }

        public Task<List<Paymast>> GetAll()
        {
            return _context.Paymasts.OrderBy(p => p.fixTaxRate).ToListAsync();
        }

        public Task<Paymast?> GetById(Guid id)
        {
            return _context.Paymasts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
