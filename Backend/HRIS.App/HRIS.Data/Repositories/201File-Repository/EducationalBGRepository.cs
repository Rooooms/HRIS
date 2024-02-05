using HRIS.Core.Entities;
using HRIS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Repositories
{
    public class EducationalBGRepository : IEducationalBGRepository
    {
        private readonly AppDbContext _context;

        public EducationalBGRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(EducationalBg newEducationalBg)
        {
            _context.EducationalBackground.Add(newEducationalBg);
        }

        public void Delete(EducationalBg educationalBg)
        {
            _context.EducationalBackground.Remove(educationalBg);
        }

        public Task<List<EducationalBg>> GetAll()
        {
            return _context.EducationalBackground.OrderBy(p => p.Degree).ToListAsync();
        }

        public Task<EducationalBg?> GetById(Guid id)
        {
            return _context.EducationalBackground.FirstOrDefaultAsync(p => p.Id == id);
        }

       
        public Task<int> SaveChangesAysnc()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<EducationalBg>> GetEducationalBgByEmployeeId(Guid employeeId)
        {
            return _context.EducationalBackground.Where(p => p.EmployeeId == employeeId).ToListAsync();
        }
       
    }
}
