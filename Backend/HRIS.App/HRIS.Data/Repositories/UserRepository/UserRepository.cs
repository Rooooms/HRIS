using HRIS.Core.Entities;
using HRIS.Core.Entities.UserEntities;
using HRIS.Core.Interfaces.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User newUser)
        {
            _context.User.Add(newUser);
        }

        public void Delete(User user)
        {
            _context.User.Remove(user);
        }

        public Task<List<User>> GetAll()
        {
            return _context.User.OrderBy(p => p.UserName).ToListAsync();
        }

        public Task<User?> GetById(Guid id)
        {
            return _context.User.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<User?> GetUserByEmpNumber(int employeeNumber)
        {
            return _context.User.FirstOrDefaultAsync(p => p.EmployeeNumber == employeeNumber);
        }

        public Task<User?> GetByUserType (string userType)
        {
            return _context.User.FirstOrDefaultAsync(p=>p.userType == userType);
        }

        public Task<User?> GetUserByDepartment(string department)
        {
            return _context.User.FirstOrDefaultAsync(p => p.Department == department);
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }
    }
}
