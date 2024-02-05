using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using HRIS.Data;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Service.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly IEmployeeDetailsRepository _employee;
        public readonly ISalaryRepository _salary;
        public readonly AppDbContext _context;


        public SalaryService(IEmployeeDetailsRepository employee, AppDbContext context, ISalaryRepository salary)
        {
            _salary = salary;
            _context = context;
            _employee = employee;
        }

        public async Task<List<SalaryResponse>> GetAll()
        {
            var salary = await _salary.GetAll();
            var salaryDto = salary.Adapt<List<SalaryResponse>>();

            return salaryDto;
        }

        public async Task<SalaryResponse?> GetById(Guid id)
        {
            var salary = await _salary.GetById(id);


            var salaryDto = salary?.Adapt<SalaryResponse>();

            return salaryDto;
        }

        public async Task<SalaryResponse> Create(Guid id, SalaryRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var salary = request.Adapt<Salary>();
            
            salary.Employee = employee;
            salary.EmployeeId = employee.Id;

            _salary.Add(salary);

            await _salary.SaveChangesAysnc();

            var salaryDto = salary.Adapt<SalaryResponse>();
            return salaryDto;
        }

        public async Task<SalaryResponse> Update(Guid id, SalaryRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var salary = await _salary.GetById(id);

            if (salary == null) return null;

            request.Adapt(salary);

            salary.Employee = employee;
            salary.EmployeeId = employee.Id;

            await _salary.SaveChangesAysnc();

            return salary.Adapt<SalaryResponse>();


        }

        public async Task<bool> Delete(Guid id)
        {
            var salary = await _salary.GetById(id);

            if (salary == null) return false;

            _salary.Delete(salary);

            await _salary.SaveChangesAysnc();

            return true;
        }
    }
}
