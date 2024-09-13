using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PassportAPK.API.Models;
using System.Reflection.Emit;

namespace PassportAPK.API.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Adding Roles in table.
            List<IdentityRole> roles = new List<IdentityRole> 
            {
                new IdentityRole(){ Name = "Admin" , NormalizedName = "ADMIN"},
                new IdentityRole(){ Name = "User" , NormalizedName = "USER"}
            };

            builder.Entity<IdentityRole>().HasData(roles);

           
        }

        // Entities
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRequired> ServiceRequireds { get; set; }
        public DbSet<ApplicantDetails> ApplicantDetails { get; set; }
        public DbSet<ResidentailDetails> ResidentailDetails { get; set; }
        public DbSet<FamilyDetails> FamilyDetails { get; set; }
        public DbSet<EmergencyContactDetails> EmergencyContactDetails { get; set; }
        public DbSet<OtherDetails> OtherDetails { get; set; }
        public DbSet<SelfDeclaration> SelfDeclarations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MasterDetailsTable> MasterDetailsTables { get; set; }
    }
}
