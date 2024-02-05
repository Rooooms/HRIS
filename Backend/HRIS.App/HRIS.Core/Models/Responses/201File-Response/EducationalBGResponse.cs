using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Responses
{
    public class EducationalBGResponse
    {
        public Guid Id { get; set; }

        public string? Degree { get; set; }

        public string? GradSchool { get; set; }

        public string? License { get; set; }

        public string? ElemInstitute { get; set; }

        public string? ElemLoc { get; set; }

        public string? ElemDateInc { get; set; }

        public string? elemAchievement { get; set; }

        public string? HsInstitute { get; set; }

        public string? HsLoc { get; set; }

        public string? HsDateInc { get; set; }

        public string? HsAchievement { get; set; }

        public string? TerInstitute { get; set; }

        public string? TerLoc { get; set; }

        public string? TerDateInc { get; set; }

        public string? TerAchievement { get; set; }

        public Guid EmployeeId { get; set; }
        
    }
}
