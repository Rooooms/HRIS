using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public int? CompanyNumber { get; set; }

        public CompanyStatus Status { get; set; }
    }


    public enum CompanyStatus : byte
    {
        Active, Inactive
    }
}
