using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IBenefitService
    {
        Task<List<BenefitResponse>> GetAll();

        Task<BenefitResponse?> GetById(Guid id);

        Task<BenefitResponse> Create(Guid id, BenefitRequest request);

        Task<BenefitResponse> Update(Guid id, BenefitRequest request);

        Task<bool> Delete(Guid id);
    }
}
