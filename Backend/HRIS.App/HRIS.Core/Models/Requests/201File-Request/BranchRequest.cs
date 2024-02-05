using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Requests
{
    public class BranchRequest
    {
        public string Location { get; set; }
        public string BranchCode { get; set; }

        public string CompanyName { get; set; }


    }
}
