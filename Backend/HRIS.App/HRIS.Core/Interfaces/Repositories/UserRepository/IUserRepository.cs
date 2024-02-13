using HRIS.Core.Entities;
using HRIS.Core.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User?> GetById(Guid id);
        void Add(User newUser);

        void Delete(User user);

        Task<int> SaveChangesAysnc();

        Task<User?> GetUserByEmpNumber(int employeeNumber);
        Task<User?> GetUserByDepartment(string department);

        Task<User?> GetByUserType(string userType);
    }
}
