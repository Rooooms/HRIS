using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities
{
    public class Benefit
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public EmployeeDetails EmployeeDetails { get; set; } 

        public string BenefitName { get; set; }

        public double BenefitAmount { get; set; }   

        public DateTime DateGiven { get; set; }
    }
}
