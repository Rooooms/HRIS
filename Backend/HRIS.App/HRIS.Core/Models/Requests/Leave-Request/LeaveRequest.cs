using HRIS.Core.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Requests.Leave_Request
{
    public class LeaveRequest
    {
        public DateTime LeaveStartDate { get; set; }

        public DateTime LeaveEndDate { get; set; }


        public string Reason { get; set; }
        public string? Status { get; set; }

        public string? ResOfCancel { get; set; }

    }

    
}
