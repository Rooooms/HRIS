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
    public class BranchService : IBranchService
    {
        public readonly IBranchRepository _branch;
        public readonly AppDbContext _context;
        private readonly ICompanyRepository _company;

        public BranchService(IBranchRepository branch, AppDbContext context, ICompanyRepository company)
        {
            _branch = branch;
            _context = context;
            _company = company;
        }

        public async Task<BranchResponse> Create(BranchRequest request)
        {
            var company = await _company.GetByCompany(request.CompanyName);
            if (company == null) return null;

            var branch = request.Adapt<Branch>();

            branch.Status = BranchStatus.Active;

            branch.Company = company;
            branch.CompanyName = company.CompanyName;
            branch.CompanyId = company.Id;

            _branch.Add(branch);
            await _branch.SaveChangesAysnc();

            var branchDto = branch.Adapt<BranchResponse>();
            return branchDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var branch = await _branch.GetById(id);

            if (branch == null) return false;

            _branch.Delete(branch);

            await _branch.SaveChangesAysnc();

            return true;
        }

        public async Task<List<BranchResponse>> GetAll()
        {
            var branch = await _branch.GetAll();
            var branchDto = branch.Adapt<List<BranchResponse>>();

            return branchDto;
        }

        public async Task<List<Branch>> GetBranchByCompanyId(Guid CompanyId)
        {
            var branch = await _branch.GetBranchByCompanyId(CompanyId);

            return branch;
        }

        public async Task<BranchResponse?> GetById(Guid id)
        {
            var branch = await _branch.GetById(id);


            var branchDto = branch?.Adapt<BranchResponse>();

            return branchDto;
        }

        public async Task<List<BranchResponse>> GetBySearch(string search)
        {
            var branch = await _branch.GetBySearch(search);

            var branchDto = _branch.Adapt<List<BranchResponse>>();

            return branchDto;
        }

        public async Task<BranchResponse> Update(Guid id, BranchRequest request)
        {
            var company = await _company.GetByCompany(request.CompanyName);
            if (company == null)
                return null;
            var branch = await _branch.GetById(id);

            if (branch == null) return null;

            request.Adapt(branch);

            branch.Company = company;
            branch.CompanyName = company.CompanyName;
            branch.CompanyId = company.Id;

            await _branch.SaveChangesAysnc();

            return branch.Adapt<BranchResponse>();
        }
    }
}
