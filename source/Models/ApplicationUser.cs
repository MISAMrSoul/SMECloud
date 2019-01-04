using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Misa.SmeNetCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public override string Id {get;set;}
        public string IDNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IsuedPlace { get; set; }
        public bool? IsActive { get; set; }
        public string FullName{get;set;}
    }
}