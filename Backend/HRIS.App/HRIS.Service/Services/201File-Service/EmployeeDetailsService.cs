using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using HRIS.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Service.Services
{
    public class EmployeeDetailsService : IEmployeeDetailService
    {
        public readonly IEmployeeDetailsRepository _employeeDetails;
        private readonly IBranchRepository _branch;
        public readonly AppDbContext _context;
        private readonly ICompanyRepository _company;

        public EmployeeDetailsService(IEmployeeDetailsRepository employeeDetails, IBranchRepository branch, AppDbContext context, ICompanyRepository company)
        {
            _branch = branch;
            _context = context;
            _company = company;
            _employeeDetails = employeeDetails;
        }

        public async Task<List<EmployeeDetailsResponse>> GetAll()
        {
            var employeeDetails = await _employeeDetails.GetAll();
            var employeeDetailsDto = employeeDetails.Adapt<List<EmployeeDetailsResponse>>();

            return employeeDetailsDto;
        }

        public async Task<EmployeeDetailsResponse?> GetById(Guid id)
        {
            var employeeDetails = await _employeeDetails.GetById(id);


            var employeeDetailsDto = employeeDetails?.Adapt<EmployeeDetailsResponse>();

            return employeeDetailsDto;
        }

        public async Task<List<EmployeeDetailsResponse>> GetBySearch(string search)
        {
            var employeeDetails = await _employeeDetails.GetBySearch(search);

            var employeeDetailsDto = employeeDetails.Adapt<List<EmployeeDetailsResponse>>();
            return employeeDetailsDto;
        }

        public async Task<EmployeeDetailsResponse> Create(EmployeeDetailsRequest request)
        {
            var company = await _company.GetByCompany(request.CompanyName);

            if (company == null) return null;



            // Generate the next employee number
            int nextEmployeeNumber = await _employeeDetails.GenerateNextEmployeeNumberAsync();

            var employeeDetails = request.Adapt<EmployeeDetails>();

            employeeDetails.company = company;
            employeeDetails.CompanyId = company.Id;

            // Assign the generated employee number
            employeeDetails.EmployeeNumber = nextEmployeeNumber;

            employeeDetails.BirthDate = request.BirthDate ?? null;
            employeeDetails.EmpDate = request.EmpDate ?? null;
            employeeDetails.DesigDate = request.DesigDate ?? null;
            employeeDetails.SepDate = request.SepDate ?? null;
            employeeDetails.SalesDate = request.SalesDate ?? null;
            employeeDetails.EvalDate = request.EvalDate ?? null;

            _employeeDetails.Add(employeeDetails);

            await _employeeDetails.SaveChangesAysnc();

            var employeeDetailsDto = employeeDetails.Adapt<EmployeeDetailsResponse>();
            return employeeDetailsDto;
        }

        public async Task<EmployeeDetailsResponse> Update(Guid id, EmployeeDetailsRequest request)
        {
            var company = await _company.GetByCompany(request.CompanyName);

            if (company == null) return null;



            var employeeDetails = await _employeeDetails.GetById(id);

            if (employeeDetails == null) return null;

            request.Adapt(employeeDetails);

            if (employeeDetails.EmployeeNumber == 0) // Assuming 0 means it's a new employee
            {
                employeeDetails.EmployeeNumber = await GenerateNextEmployeeNumberAsync();
            }


            employeeDetails.company = company;

            employeeDetails.CompanyId = company.Id;


            await _employeeDetails.SaveChangesAysnc();

            return employeeDetails.Adapt<EmployeeDetailsResponse>();


        }

        public async Task<int> GenerateNextEmployeeNumberAsync()
        {
            // You can fetch the last assigned employee number from a database table or other persistent storage
            // For simplicity, let's assume you have a service method to get the last employee number
            int lastEmployeeNumber = await _employeeDetails.GetLastEmployeeNumberAsync();

            // Increment the last employee number to generate the next one
            int nextEmployeeNumber = lastEmployeeNumber + 1;

            // Save the next employee number for future use
            await _employeeDetails.SaveLastEmployeeNumberAsync(nextEmployeeNumber);

            return nextEmployeeNumber;
        }





        public async Task<bool> Delete(Guid id)
        {

            var employeeDetails = await _employeeDetails.GetById(id);
            if (employeeDetails == null) return false;

            _employeeDetails.Delete(employeeDetails);

            await _employeeDetails.SaveChangesAysnc();

            return true;

        }
    }


        
}


