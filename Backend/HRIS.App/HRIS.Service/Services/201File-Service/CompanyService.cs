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
    public class CompanyService : ICompanyService
    {
        public readonly ICompanyRepository _company;
        public readonly AppDbContext _context;


        public CompanyService(ICompanyRepository company, AppDbContext context)
        {
            _company = company;
            _context = context;
        }

        public async Task<CompanyResponse> Create(CompanyRequest request)
        {

            var company = request.Adapt<Company>();

            company.Status = CompanyStatus.Active;

            _company.Add(company);
            await _company.SaveChangesAysnc();


            var companyDto = company.Adapt<CompanyResponse>();

            return companyDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var company = await _company.GetById(id);

            if (company == null) return false;

            _company.Delete(company);

            await _company.SaveChangesAysnc();

            return true;
        }

        public async Task<List<CompanyResponse>> GetAll()
        {
            var company = await _company.GetAll();
            var companyDto = company.Adapt<List<CompanyResponse>>();

            return companyDto;
        }

        public async Task<CompanyResponse?> GetById(Guid id)
        {
            var company = await _company.GetById(id);


            var companyDto = company?.Adapt<CompanyResponse>();

            return companyDto;
        }

        public async Task<List<CompanyResponse>> GetBySearch(string search)
        {
            var company = await _company.GetBySearch(search);

            var companyDto = company.Adapt<List<CompanyResponse>>();

            return companyDto;
        }

        public async Task<CompanyResponse> Update(Guid id, CompanyRequest request)
        {
            var company = await _company.GetById(id);


            if (company == null) return null;



            request.Adapt(company);

            await _company.SaveChangesAysnc();

            return _company.Adapt<CompanyResponse>();
        }
    }
}
