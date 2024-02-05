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
    public class EmploymentBackgroundService : IEmploymentBackgroundService
    {
        private readonly IEmployeeDetailsRepository _employee;
        public readonly IEmploymentBackgroundRepository _employmentBg;
        public readonly AppDbContext _context;


        public EmploymentBackgroundService(IEmployeeDetailsRepository employee, AppDbContext context, IEmploymentBackgroundRepository employmentBg)
        {
            _employmentBg = employmentBg;
            _context = context;
            _employee = employee;
        }

        public async Task<List<EmploymentBackgroundResponse>> GetAll()
        {
            var employmentBg = await _employmentBg.GetAll();
            var employmentBgDto = employmentBg.Adapt<List<EmploymentBackgroundResponse>>();

            return employmentBgDto;
        }

        public async Task<EmploymentBackgroundResponse?> GetById(Guid id)
        {
            var employmentBg = await _employmentBg.GetById(id);


            var employmentBgDto = employmentBg?.Adapt<EmploymentBackgroundResponse>();

            return employmentBgDto;
        }

        public async Task<EmploymentBackgroundResponse> Create(Guid id, EmploymentBackgroundRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var employmentBg = request.Adapt<EmploymentBackground>();

            employmentBg.Employee = employee;
            employmentBg.EmployeeId = employee.Id;

            _employmentBg.Add(employmentBg);

            await _employmentBg.SaveChangesAysnc();

            var employmentBgDto = employmentBg.Adapt<EmploymentBackgroundResponse>();
            return employmentBgDto;
        }

        public async Task<EmploymentBackgroundResponse> Update(Guid id, EmploymentBackgroundRequest request)
        {
            

            var employmentBg = await _employmentBg.GetById(id);

            if (employmentBg == null) return null;

            request.Adapt(employmentBg);

            

            await _employmentBg.SaveChangesAysnc();

            return employmentBg.Adapt<EmploymentBackgroundResponse>();


        }

        public async Task<bool> Delete(Guid id)
        {
            var employmentBg = await _employmentBg.GetById(id);

            if (employmentBg == null) return false;

            _employmentBg.Delete(employmentBg);

            await _employmentBg.SaveChangesAysnc();

            return true;
        }
    }
}
