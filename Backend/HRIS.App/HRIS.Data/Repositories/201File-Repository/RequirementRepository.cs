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
    public class RequirementRepository :  IRequirementRepository
    {
        private readonly AppDbContext _context;

        public RequirementRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Requirement newRequirement)
        {
            _context.Requirements.Add(newRequirement);
        }

        public void Delete(Requirement requirement)
        {
            _context.Requirements.Remove(requirement);
        }

        public Task<List<Requirement>> GetAll()
        {
            return _context.Requirements.OrderBy(p => p.polygraph).ToListAsync();
        }

        public Task<Requirement?> GetById(Guid id)
        {
            return _context.Requirements.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
