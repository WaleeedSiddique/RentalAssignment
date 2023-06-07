using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalAssignment.Models;

namespace RentalAssignment.DatabaseContext
{
    public class AddDbContext : IdentityDbContext
    {
        public AddDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rental> rentals { get; set; }
        public DbSet<Review> reviews { get; set; }

    }
}
