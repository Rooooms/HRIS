using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities
{
    public class Paymast
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public EmployeeDetails EmployeeDetails { get; set; }


        public double fixTaxRate { get; set; }

        public double baseMonthly {  get; set; }

        public double base15th { get; set; }

        public double baseMonthEnd { get; set; }

        public double colaMonthly { get; set; }

        public double cola15th { get;set; }

        public double colaMonthEnd { get; set; }

        public double empShare {  get; set; }

        public double medAllowance { get; set;}

        public double dailyShare { get; set; }

        public string depName { get; set; }

        public DateTime depBirthday { get; set; }

        public string ctcNo { get; set; }

        public DateTime dateIssue { get; set; }

        public string rateType { get; set; }

        public string placeIssue { get; set; }

        public string payslipPinNo { get; set; }

        public bool excPayrollProcess { get; set; }
    }
}
