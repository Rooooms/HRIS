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
    public class ApexMerchService : IApexMerchService
    {
        private readonly IEmployeeDetailsRepository _employee;
        public readonly IApexMerchRepository _apexMerch;
        public readonly AppDbContext _context;


        public ApexMerchService(IEmployeeDetailsRepository employee, AppDbContext context, IApexMerchRepository apexMerch)
        {
            _apexMerch = apexMerch;
            _context = context;
            _employee = employee;
        }

        public async Task<List<ApexMerchResponse>> GetAll()
        {
            var apexMerch = await _apexMerch.GetAll();
            var apexMerchDto = apexMerch.Adapt<List<ApexMerchResponse>>();

            return apexMerchDto;
        }

        public async Task<ApexMerchResponse?> GetById(Guid id)
        {
            var apexMerch = await _apexMerch.GetById(id);


            var apexMerchDto = apexMerch?.Adapt<ApexMerchResponse>();

            return apexMerchDto;
        }

        public async Task<ApexMerchResponse> Create(Guid id, ApexMerchRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var apexMerch = request.Adapt<ApexMerch>();

            apexMerch.EmployeeDetails = employee;

            apexMerch.EmployeeId = employee.Id;

            _apexMerch.Add(apexMerch);

            await _apexMerch.SaveChangesAysnc();

            var apexMerchDto = apexMerch.Adapt<ApexMerchResponse>();
            return apexMerchDto;
        }

        public async Task<ApexMerchResponse> Update(Guid id, ApexMerchRequest request)
        {

            var apexMerch = await _apexMerch.GetById(id);

            if (apexMerch == null) return null;

            request.Adapt(apexMerch);



            await _apexMerch.SaveChangesAysnc();

            return apexMerch.Adapt<ApexMerchResponse>();


        }

        public async Task<bool> Delete(Guid id)
        {
            var apexMerch = await _apexMerch.GetById(id);

            if (apexMerch == null) return false;

            _apexMerch.Delete(apexMerch);

            await _apexMerch.SaveChangesAysnc();

            return true;
        }
    }
}
