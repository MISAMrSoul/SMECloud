using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Misa.SmeNetCore.Models;

namespace Misa.SmeNetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserCompany>().HasKey(u => new { u.UserID, u.CompanyID });
            builder.Entity<ApplicationUser>().Property(o => o.IsActive).HasDefaultValue(true);
            builder.Entity<UserCompany>().HasOne("Misa.SmeNetCore.Models.ApplicationUser").WithMany().HasForeignKey("UserID").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserCompany>().HasOne("Misa.SmeNetCore.Models.Company").WithMany().HasForeignKey("CompanyID").OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
    }
}