using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities
{
    public class ApexMerch
    { 
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public EmployeeDetails EmployeeDetails { get; set; }

        public bool IsRAM {  get; set; }

        public bool IsMitra { get; set; }

        public bool IsSevilla { get; set; }

        public bool IsVar {  get; set; }

        public bool IsInfini { get; set; }

        public string RamPercent { get; set; }

        public int NoOutlet { get; set; }

        public string SevPercent { get; set; }

        public string varAmount { get; set; }

        public string infiniAmount { get; set; }

    }
}
