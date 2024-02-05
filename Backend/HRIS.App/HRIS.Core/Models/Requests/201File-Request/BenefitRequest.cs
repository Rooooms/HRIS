using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Requests
{
    public class BenefitRequest
    {
     

        public string BenefitName { get; set; }

        public double BenefitAmount { get; set; }

        public DateTime DateGiven { get; set; }
    }
}
