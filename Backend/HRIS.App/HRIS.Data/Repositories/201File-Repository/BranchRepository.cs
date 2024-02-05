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
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _context;

        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Branch newBranch)
        {
            _context.Branches.Add(newBranch);
        }

        public void Delete(Branch branch)
        {
            _context.Branches.Remove(branch);
        }

        public Task<List<Branch>> GetAll()
        {
            return _context.Branches.OrderBy(p => p.Location).ToListAsync();
        }

        public Task<Branch?> GetById(Guid id)
        {
            return _context.Branches.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Branch>> GetBySearch(string search)
        {
            return _context.Branches.Where(p => p.Location.Contains(search)).ToListAsync();
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
        public Task<List<Branch>> GetBranchByCompanyId(Guid companyId)
        {
            return _context.Branches.Where(p => p.CompanyId == companyId).ToListAsync();
        }

        public Task<Branch?> GetByBranch(string branchLocation)
        {
            return _context.Branches.FirstOrDefaultAsync(p => p.Location == branchLocation);
        }
    }
}
