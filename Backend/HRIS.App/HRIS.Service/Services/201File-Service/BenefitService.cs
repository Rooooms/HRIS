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
    public class BenefitService : IBenefitService
    {
        private readonly IEmployeeDetailsRepository _employee;
        public readonly IBenefitRepository _benefit;
        public readonly AppDbContext _context;


        public BenefitService(IEmployeeDetailsRepository employee, AppDbContext context, IBenefitRepository benefit)
        {
            _benefit = benefit;
            _context = context;
            _employee = employee;
        }

        public async Task<List<BenefitResponse>> GetAll()
        {
            var benefit = await _benefit.GetAll();
            var benefitDto = benefit.Adapt<List<BenefitResponse>>();

            return benefitDto;
        }

        public async Task<BenefitResponse?> GetById(Guid id)
        {
            var benefit = await _benefit.GetById(id);


            var benefitDto = benefit?.Adapt<BenefitResponse>();

            return benefitDto;
        }

        public async Task<BenefitResponse> Create(Guid id, BenefitRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var benefit = request.Adapt<Benefit>();

            benefit.EmployeeDetails = employee;

            benefit.EmployeeId = employee.Id;

            _benefit.Add(benefit);

            await _benefit.SaveChangesAysnc();

            var benefitDto = benefit.Adapt<BenefitResponse>();
            return benefitDto;
        }

        public async Task<BenefitResponse> Update(Guid id, BenefitRequest request)
        {

            var benefit = await _benefit.GetById(id);

            if (benefit == null) return null;

            request.Adapt(benefit);



            await _benefit.SaveChangesAysnc();

            return benefit.Adapt<BenefitResponse>();


        }

        public async Task<bool> Delete(Guid id)
        {
            var benefit = await _benefit.GetById(id);

            if (benefit == null) return false;

            _benefit.Delete(benefit);

            await _benefit.SaveChangesAysnc();

            return true;
        }
    }
}
