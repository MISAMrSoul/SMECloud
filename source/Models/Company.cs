using System;
using System.ComponentModel.DataAnnotations;

namespace Misa.SmeNetCore.Models
{
    public class Company
    {
        [Key]
        public string CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Community { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public string BankAdress { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string CurrentVersion { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyedBy { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public string TaxCode {get;set;}
    }
}