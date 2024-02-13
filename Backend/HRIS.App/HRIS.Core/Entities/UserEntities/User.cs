using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities.UserEntities
{
    public class User
    {

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; } 

        public int EmployeeNumber { get; set; }

        public string? token { get; set; }

        public string userType { get; set; }

        public Guid EmployeeId { get; set; }

        public string employeeName { get; set; }

        public string Department { get; set; }

        public EmployeeDetails employeeDetails { get; set; }

    }

    
}
