using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IRequirementService
    {
        Task<List<RequirementResponse>> GetAll();

        Task<RequirementResponse?> GetById(Guid id);

        Task<RequirementResponse> Create(Guid id, RequirementsRequest request);

        Task<RequirementResponse> Update(Guid id, RequirementsRequest request);

        Task<bool> Delete(Guid id);
    }
}
