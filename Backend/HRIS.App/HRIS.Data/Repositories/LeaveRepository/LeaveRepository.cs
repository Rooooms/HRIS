using HRIS.Core.Entities.Leave_Entities;

using HRIS.Core.Interfaces.Repositories.Leaves_Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Repositories.LeaveRepository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _context;

        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(LeaveEntities newLeave)
        {
            _context.Leaves.Add(newLeave);
        }

        public void Delete(LeaveEntities leave)
        {
            _context.Leaves.Remove(leave);
        }

        public Task<List<LeaveEntities>> GetAll()
        {
            return _context.Leaves.OrderBy(p => p.DateSubmitted).ToListAsync();
        }

        public Task<LeaveEntities?> GetById(Guid id)
        {
            return _context.Leaves.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<List<LeaveEntities>> GetLeavesByEmployeeNumber(int employeeNumber)
        {
            return await _context.Leaves.Where(leave => leave.EmployeeNumber == employeeNumber).ToListAsync();
        }
    }
}
