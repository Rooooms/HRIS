using HRIS.Core.Entities;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Interfaces.Services
{
    public interface IEducationalBGService
    {
        Task<List<EducationalBGResponse>> GetAll();

        Task<EducationalBGResponse?> GetById(Guid id);

        Task<EducationalBGResponse> Create(Guid id, EducationalBGRequest request);

        Task<EducationalBGResponse> Update(Guid id, EducationalBGRequest request);

        Task<List<EducationalBg>> GetEducationalBgbyEmployeeId(Guid employeeId);
        Task<bool> Delete(Guid id);
    }
}
