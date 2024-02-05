using HRIS.Core.Entities.UserEntities;
using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Responses.User_Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int EmployeeNumber { get; set; }

        public string userType { get; set; }
    }

    public class CheckLoggedResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int EmployeeNumber { get; set; }
        public string userType { get; set; }
       
    }

    public class LoginResponse
    {
        
        public string token { get; set; }
    }

    public class LoginResponseResult
    {
        public bool Success { get; set; }
        public LoginResponse Response { get; set; }
    }
}
