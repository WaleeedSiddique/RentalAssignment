using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalAssignment.Models;

namespace RentalAssignment.DatabaseContext
{

    public class AddDbContext : IdentityDbContext<ApplicationUser>
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

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
