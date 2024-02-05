using HRIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Responses
{
    public class RequirementResponse
    {
        public Guid Id { get; set; }

        public Guid employeeId { get; set; }



        public string polygraph { get; set; }

        public string PhyExam { get; set; }

        public string sssNo { get; set; }

        public string ResidentCert { get; set; }

        public string Tor { get; set; }

        public string DrvLicense { get; set; }

        public string EmpCert { get; set; }

        public string ITR { get; set; }

        public string TinNo { get; set; }

        public string PhilhealthNo { get; set; }

        public string PagibigNo { get; set; }

        public string Nbi { get; set; }

        public string MarriageCert { get; set; }

        public string Pic { get; set; }

        public string Clearance { get; set; }

        public bool IsPolygraph { get; set; }

        public bool IsPhyExam { get; set; }

        public bool IsSSSNo { get; set; }

        public bool IsResidentCert { get; set; }

        public bool IsTOR { get; set; }

        public bool IsDrvLicense { get; set; }

        public bool IsEmpCert { get; set; }

        public bool IsITR { get; set; }

        public bool IsTinNo { get; set; }

        public bool IsPhilhealthNo { get; set; }

        public bool IsPic { get; set; }

        public bool IsPagibig { get; set; }

        public bool IsNbi { get; set; }


        public bool IsMarriageCert { get; set; }

        public bool IsClearance { get; set; }
    }
}
