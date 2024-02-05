using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IApexMerchService
    {
        Task<List<ApexMerchResponse>> GetAll();

        Task<ApexMerchResponse?> GetById(Guid id);

        Task<ApexMerchResponse> Create(Guid id, ApexMerchRequest request);

        Task<ApexMerchResponse> Update(Guid id, ApexMerchRequest request);

        Task<bool> Delete(Guid id);
    }
}
