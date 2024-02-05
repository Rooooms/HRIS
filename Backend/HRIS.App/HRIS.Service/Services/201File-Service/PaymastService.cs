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
    public class PaymastService : IPaymastService
    {
        private readonly IEmployeeDetailsRepository _employee;
        public readonly IPaymastRepository _paymast;
        public readonly AppDbContext _context;


        public PaymastService(IEmployeeDetailsRepository employee, AppDbContext context, IPaymastRepository paymast)
        {
            _paymast = paymast;
            _context = context;
            _employee = employee;
        }

        public async Task<List<PaymastResponse>> GetAll()
        {
            var paymast = await _paymast.GetAll();
            var paymastDto = paymast.Adapt<List<PaymastResponse>>();

            return paymastDto;
        }

        public async Task<PaymastResponse?> GetById(Guid id)
        {
            var paymast = await _paymast.GetById(id);


            var paymastDto = paymast?.Adapt<PaymastResponse>();

            return paymastDto;
        }

        public async Task<PaymastResponse> Create(Guid id, PaymastRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var paymast = request.Adapt<Paymast>();

            paymast.EmployeeDetails = employee;

            paymast.EmployeeId = employee.Id;

            _paymast.Add(paymast);

            await _paymast.SaveChangesAysnc();

            var paymastDto = paymast.Adapt<PaymastResponse>();
            return paymastDto;
        }

        public async Task<PaymastResponse> Update(Guid id, PaymastRequest request)
        {

            var paymast = await _paymast.GetById(id);

            if (paymast == null) return null;

            request.Adapt(paymast);



            await _paymast.SaveChangesAysnc();

            return paymast.Adapt<PaymastResponse>();


        }

        public async Task<bool> Delete(Guid id)
        {
            var paymast = await _paymast.GetById(id);

            if (paymast == null) return false;

            _paymast.Delete(paymast);

            await _paymast.SaveChangesAysnc();

            return true;
        }
    }
}
