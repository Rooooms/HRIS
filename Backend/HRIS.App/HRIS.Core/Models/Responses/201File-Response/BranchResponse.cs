using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Responses
{
   
    public class BranchResponse
    {
        public Guid Id { get; set; }

        public string Location { get; set; }
        public string BranchCode { get; set; }

        public string CompanyName { get; set; }

        public BranchStatus Status { get; set; }
        public Guid CompanyId { get; set; }


    }
}
