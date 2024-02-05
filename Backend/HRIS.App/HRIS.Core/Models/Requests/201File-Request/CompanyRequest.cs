using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Requests
{
    public class CompanyRequest
    {
        public string? CompanyName { get; set; }
        public int? CompanyNumber { get; set; }
    }
}
