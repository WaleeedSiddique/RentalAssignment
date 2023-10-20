using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalAssignment.Models;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;

namespace RentalAssignment.DatabaseContext
{

    public class AddDbContext : IdentityDbContext<ApplicationUser>
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
            var appuser = new ApplicationUser()
            {
                UserName = "TestUser",
                Email = "Test@gmail.com",
                EmailConfirmed = false,
                IsApproved = true,
            };
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appuser.PasswordHash = ph.HashPassword(appuser, "Test@123");

        }

        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rental> rentals { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<ApplicationUser> applicationusers { get; set; }
        public DbSet<Contact> contact { get; set; }

    }
}