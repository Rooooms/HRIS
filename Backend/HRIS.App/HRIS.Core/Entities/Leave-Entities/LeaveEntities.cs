using HRIS.Core.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities.Leave_Entities
{
    public class LeaveEntities
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }    

        public User? users { get; set; }

        public Guid EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public int EmployeeNumber { get; set; }

        public int UserLevel { get; set; }
        public string? Company {  get; set; }

        public string? Branch { get; set; }

        public string? Department { get; set; }

        public DateTime LeaveStartDate { get; set; }

        public DateTime LeaveEndDate { get; set;}

        public DateTime DateSubmitted { get; set; }
        public int LastSubmissionMonth { get; set; }
        public int LastSubmissionYear { get; set; }

        public string? Status { get; set; }

        public string? Reason { get; set; }

        public double Credit {  get; set; }

        public string? ResOfCancel { get; set; }
    }
}
