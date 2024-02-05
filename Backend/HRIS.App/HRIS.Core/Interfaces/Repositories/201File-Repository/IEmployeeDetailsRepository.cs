using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Repositories
{
    public interface IEmployeeDetailsRepository
    {
        Task<List<EmployeeDetails>> GetAll();

        Task<EmployeeDetails?> GetById(Guid id);

        Task<List<EmployeeDetails>> GetBySearch(string search);
        //Task<Company?> GetByCategory(string companyName);
        Task<EmployeeDetails?> GetByEmployee(int employeeNumber);


        void Add(EmployeeDetails newEmployee);

        void Delete(EmployeeDetails employee);

        Task<int> SaveChangesAysnc();

        Task<int> GetLastEmployeeNumberAsync();

        Task SaveLastEmployeeNumberAsync(int lastEmployeeNumber);

        Task<int> GenerateNextEmployeeNumberAsync();
    }
}
