using System.ComponentModel.DataAnnotations;
using Misa.SmeNetCore.Models;

namespace Misa.SmeNetCore.Models.CompanyViewModels
{
    public class RegisterCompanyViewModel
    {
        [Required]
        [Display(Name = "Tên công ty")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Mã số thuế ")]
        public string TaxCode { get; set; }

        public string UserID { get; set; }
    }
}