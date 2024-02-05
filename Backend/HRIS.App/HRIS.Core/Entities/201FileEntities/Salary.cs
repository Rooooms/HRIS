using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities
{
    public class Salary
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public EmployeeDetails Employee { get; set; }


        public double fixrate { get; set; }

        public string PayType { get; set; }

        public double Monthly { get; set; }

        public double MidMonth { get; set; }

        public double EndMonth { get; set; }


        public double OTRate { get; set; }

        public double DailyRate { get; set; }
    }
}
