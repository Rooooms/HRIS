using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Repositories._201File_Repository
{
    public class EmployeeDetailsRepository : IEmployeeDetailsRepository
    {
        private readonly AppDbContext _context;

        public EmployeeDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(EmployeeDetails newEmployee)
        {
            _context.Employee_Details.Add(newEmployee);
        }

        public void Delete(EmployeeDetails employee)
        {
            _context.Employee_Details.Remove(employee);
        }

        public Task<List<EmployeeDetails>> GetAll()
        {
            return _context.Employee_Details.OrderBy(p => p.EmployeeNumber).ToListAsync();
        }

        public Task<EmployeeDetails?> GetById(Guid id)
        {
            return _context.Employee_Details.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<EmployeeDetails>> GetBySearch(string search)
        {
            return _context.Employee_Details.Where(p => p.LName.Contains(search)).ToListAsync();
        }

        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }

        public Task<EmployeeDetails?> GetByEmployee(int employeeNumber)
        {
            return _context.Employee_Details.FirstOrDefaultAsync(p => p.EmployeeNumber == employeeNumber);
        }

        public async Task<int> GetLastEmployeeNumberAsync()
        {
            // Assuming you want the maximum employee number from the Employees table
            int lastEmployeeNumber = await _context.Employee_Details
                .MaxAsync(e => (int?)e.EmployeeNumber) ?? 0;

            return lastEmployeeNumber;
        }

        public async Task SaveLastEmployeeNumberAsync(int lastEmployeeNumber)
        {
            // Fetch the employee with a specific condition, assuming there's only one record
            var lastEmployee = await _context.Employee_Details
                .Where(e => e.EmployeeNumber == lastEmployeeNumber)
                .FirstOrDefaultAsync();

            if (lastEmployee != null)
            {
                // Update the EmployeeNumber for the record
                lastEmployee.EmployeeNumber = lastEmployeeNumber;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            // If the record doesn't exist, you may handle this case accordingly based on your requirements
        }

        public async Task<int> GenerateNextEmployeeNumberAsync()
        {
            // You can fetch the last assigned employee number from a database table or other persistent storage
            // For simplicity, let's assume you have a service method to get the last employee number
            int lastEmployeeNumber = await GetLastEmployeeNumberAsync();

            // Increment the last employee number to generate the next one
            int nextEmployeeNumber = lastEmployeeNumber + 1;

            // Save the next employee number for future use
            await SaveLastEmployeeNumberAsync(nextEmployeeNumber);

            return nextEmployeeNumber;
        }
    }
}
