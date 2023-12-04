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
            builder.Entity<Vehicle>()
                .HasOne(x => x.VehicleCategory)
                .WithMany(e => e.vehicles)
                .HasForeignKey(x => x.VehicleCategoryId);

            var appuser = new ApplicationUser()
            {
                Id = "Test2729373937898-329332ndyvyuhvjjhf8e4",
                UserName = "TestUser",
                Email = "Test@gmail.com",
                NormalizedEmail = "Test@gmail.com".ToUpper(),
                NormalizedUserName = "TestUser".ToUpper(),
                EmailConfirmed = true,
                IsApproved = true,
            };

            var appuser2 = new ApplicationUser()
            {
                Id = "Test27293wdqwdqw73937898-329332ndyvyuhvjjhf8e4",
                UserName = "TestUser2",
                Email = "Test2@gmail.com",
                NormalizedEmail = "Test2@gmail.com".ToUpper(),
                NormalizedUserName = "TestUser2".ToUpper(),
                EmailConfirmed = true,
                IsApproved = true,
            };
            var admin = new ApplicationUser()
            {
                Id = "Admin2729083033937898-329332nduyvugjvjhf8e4",
                UserName = "Admin",
                Email = "Admin@gmail.com",
                NormalizedEmail = "Admin@gmail.com".ToUpper(),
                NormalizedUserName = "Admin".ToUpper(),
                EmailConfirmed = true,
                IsApproved = true,
            };
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appuser.PasswordHash = ph.HashPassword(appuser, "Test@123");
            PasswordHasher<ApplicationUser> ph2 = new PasswordHasher<ApplicationUser>();
            appuser.PasswordHash = ph.HashPassword(appuser2, "Test@123");
            PasswordHasher<ApplicationUser> ad = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = ad.HashPassword(admin, "Admin@123");
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "Adminkahsakjsajkf99s86as79",
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = "admin8472850237"
            }
            );
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "Admin2729083033937898-329332nduyvugjvjhf8e4",
                RoleId = "Adminkahsakjsajkf99s86as79"
            });

            builder.Entity<ApplicationUser>()
                .HasData(appuser,admin,appuser2);
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