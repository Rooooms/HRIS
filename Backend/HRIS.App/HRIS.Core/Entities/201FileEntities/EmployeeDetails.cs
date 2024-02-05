using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities
{
    public class EmployeeDetails
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }       

        public string CompanyName {  get; set; }
        public string Branch { get; set; }
        public int EmployeeNumber { get; set; }

        public string CCNo { get; set; }

        public string Department { get; set; }

        public string WarehouseNo { get; set; }

        public string EmploymentType { get; set; }

        public string EmploymentRole { get; set; }
        public string Position { get; set; }

        public string RoleLevel { get; set; }

        public string PromoId { get; set; }

        public string FName { get; set; }

        public string MName { get; set; }   

        public string LName { get; set; }

        public string NE {  get; set; }

        public DateTime? BirthDate { get; set; } 
        public DateTime? EmpDate { get; set; }
        public DateTime? DesigDate { get; set; }
        public DateTime? SepDate { get; set; } 
        public DateTime? SalesDate { get; set; } 
        public DateTime? EvalDate { get; set; } 
        public bool IsEvaluation { get; set; }
        public string? EmployeeStatus { get; set; }
        public string? StatusDesc { get; set; }
        public string WorkDays { get; set; }

        public string PlateNo { get; set; }

        public string OffIn {  get; set; }

        public string OffOut { get; set; }

        public string BaseFlag { get; set; }

        public DateTime? EffDate { get; set; } = null;

        public string Adjustment {  get; set; }

        public string Region { get; set; }

        public string CheckDGT { get; set; }

        public int NoOfDays { get; set; }

        public string PayType { get; set; }

        public string Schedule {  get; set; }

        public string Rate { get; set; }

        public int UserLevel { get; set; }

        public string POB { get; set; }

        public string CivilStat { get; set; }

        public string Sex { get; set; }

        public string Citizenship { get; set; }

        public string Religion { get; set; }

        public string Email { get; set; }

        public string CityAddress { get; set; }

        public string ProvAddress { get; set; }

        public string MobileNum { get; set; }
        public string TelNum { get; set; }

        public string SpouseName { get; set; }

        public string SpouseAge { get; set; }

        public string SpouseOccupation { get; set; }

        public string ChildName { get; set; }

        public string ChildAge { get; set; }


        public string FatherName { get; set; }

        public string FatherAge { get; set;}

        public string FatherOccupation { get;set; }

        public string MotherName { get; set; }

        public string MotherAge { get; set;}

        public string MotherOccupation { get; set; }

        public string Language { get; set; }

        public string Medical {  get; set; }

        public string MedicalPurpose { get; set;}
        public string MedicalResult { get; set;}
        public string MajorIllness { get; set;}
        public string EmerPerson { get; set;}
        public string EmerPersonNumber { get; set;}

        public string BankAcc {  get; set;}

        public string BankAcc2 { get; set;}

        public string BankName { get; set;}

        public string BankName2 { get; set;}

        public string AccType { get; set;}

        public string sssNo { get; set;}

        public string exemption { get; set;}

        public string tinNo { get; set;}

        public string group { get; set;}

        public string pagibiNo { get; set;}

        public string payper {  get; set;}

        public string philhealth { get; set;}

        public bool IsPayroll { get; set;}

        public bool IsNoTax { get; set;}

        public bool IsNoSSS { get; set;}

        public bool IsNoPremium { get; set;}

        public bool IsExcludeSmanped { get; set;}


        public Company company { get; set;}

       

    }
}
