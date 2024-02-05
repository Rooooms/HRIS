using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IPaymastService
    {
        Task<List<PaymastResponse>> GetAll();

        Task<PaymastResponse?> GetById(Guid id);

        Task<PaymastResponse> Create(Guid id, PaymastRequest request);

        Task<PaymastResponse> Update(Guid id, PaymastRequest request);

        Task<bool> Delete(Guid id);
    }
}
