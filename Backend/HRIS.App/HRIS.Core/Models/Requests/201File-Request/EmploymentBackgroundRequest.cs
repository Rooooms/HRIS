using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Requests
{
    public class EmploymentBackgroundRequest
    {
        public string PrevCompany { get; set; }

        public string NatOfBusiness { get; set; }

        public string PrevPosition { get; set; }

        public double PrevSalary { get; set; }

        public string IncDate { get; set; }

        public string JobDescription { get; set; }

        public string ReasOfLeave { get; set; }

        public string Contribution { get; set; }
    }
}
