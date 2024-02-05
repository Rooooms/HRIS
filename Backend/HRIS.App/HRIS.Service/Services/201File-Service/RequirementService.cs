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
    public class RequirementService : IRequirementService
    {
        private readonly IEmployeeDetailsRepository _employee;
        public readonly IRequirementRepository _requirement;
        public readonly AppDbContext _context;


        public RequirementService(IEmployeeDetailsRepository employee, AppDbContext context, IRequirementRepository requirement)
        {
            _requirement = requirement;
            _context = context;
            _employee = employee;
        }

        public async Task<List<RequirementResponse>> GetAll()
        {
            var requirement = await _requirement.GetAll();
            var requirementDto = requirement.Adapt<List<RequirementResponse>>();

            return requirementDto;
        }

        public async Task<RequirementResponse?> GetById(Guid id)
        {
            var requirement = await _requirement.GetById(id);


            var requirementDto = requirement?.Adapt<RequirementResponse>();

            return requirementDto;
        }

        public async Task<RequirementResponse> Create(Guid id, RequirementsRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var requirement = request.Adapt<Requirement>();

            requirement.EmployeeDetails = employee;
          
            requirement.employeeId = employee.Id;

            _requirement.Add(requirement);

            await _requirement.SaveChangesAysnc();

            var requirementDto = requirement.Adapt<RequirementResponse>();
            return requirementDto;
        }

        public async Task<RequirementResponse> Update(Guid id, RequirementsRequest request)
        {

            var requirement = await _requirement.GetById(id);

            if (requirement == null) return null;

            request.Adapt(requirement);



            await _requirement.SaveChangesAysnc();

            return requirement.Adapt<RequirementResponse>();


        }

        public async Task<bool> Delete(Guid id)
        {
            var requirement = await _requirement.GetById(id);

            if (requirement == null) return false;

            _requirement.Delete(requirement);

            await _requirement.SaveChangesAysnc();

            return true;
        }
    }
}

