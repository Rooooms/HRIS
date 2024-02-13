using HRIS.Core.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Requests.User_Request
{
    public class UserRequest
    {
        public string UserName { get; set; }


        public int EmployeeNumber { get; set; }

        public string userType { get; set; }
        
       
    }
    public class UpdateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int EmployeeNumber { get; set; }

        public string userType { get; set; }


    }



    public class LoginRequest
    {
        public int EmployeeNumber { get; set; }
        public string Password { get; set; }
    }

    public class checkloggedRequest
    {
        public int EmployeeNumber { get; set;}
    }
}
