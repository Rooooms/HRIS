using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Responses;
using HRIS.Data;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Service.Services
{
    public class EducationalBGService : IEducationalBGService
    {
        private readonly IEmployeeDetailsRepository _employee;
        public readonly IEducationalBGRepository _educationalBG;
        public readonly AppDbContext _context;


        public EducationalBGService(IEmployeeDetailsRepository employee, AppDbContext context, IEducationalBGRepository educationalBG)
        {
            _educationalBG = educationalBG;
            _context = context;
            _employee = employee;
        }

        public async Task<List<EducationalBGResponse>> GetAll()
        {
            var educationalbg = await _educationalBG.GetAll();
            var educationalbgDto = educationalbg.Adapt<List<EducationalBGResponse>>();

            return educationalbgDto;
        }

        public async Task<EducationalBGResponse?> GetById(Guid id)
        {
            var educationalbg = await _educationalBG.GetById(id);


            var educationalbgDto = educationalbg?.Adapt<EducationalBGResponse>();

            return educationalbgDto;
        }

        public async Task<EducationalBGResponse> Create(Guid id, EducationalBGRequest request)
        {
            var employee = await _employee.GetById(id);

            if (employee == null) return null;

            var educationalbg = request.Adapt<EducationalBg>();

            educationalbg.Employee = employee;
            educationalbg.EmployeeId = employee.Id;

            _educationalBG.Add(educationalbg);

            await _educationalBG.SaveChangesAysnc();

            var educationalbgDto = educationalbg.Adapt<EducationalBGResponse>();
            return educationalbgDto;
        }

        public async Task<EducationalBGResponse> Update(Guid id, EducationalBGRequest request)
        {

            var educationalbg = await _educationalBG.GetById(id);

            if (educationalbg == null) return null;

            request.Adapt(educationalbg);
            

            await _educationalBG.SaveChangesAysnc();

            return educationalbg.Adapt<EducationalBGResponse>();



        }

        public async Task<bool> Delete(Guid id)
        {
            var educationalbg = await _educationalBG.GetById(id);

            if (educationalbg == null) return false;

            _educationalBG.Delete(educationalbg);

            await _educationalBG.SaveChangesAysnc();

            return true;
        }

        public async Task<List<EducationalBg>> GetEducationalBgbyEmployeeId(Guid employeeId)
        {
            var educationalbg = await _educationalBG.GetEducationalBgByEmployeeId(employeeId);

            return educationalbg;
        }
        
    }
}
