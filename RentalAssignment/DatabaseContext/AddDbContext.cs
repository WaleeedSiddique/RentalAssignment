using Microsoft.EntityFrameworkCore;
using RentalAssignment.Models;

namespace RentalAssignment.DatabaseContext
{
    public class AddDbContext :DbContext
    {
        public AddDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rental> rentals { get; set; }

    }
}
