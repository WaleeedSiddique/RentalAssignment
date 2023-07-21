using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AddDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Vehiclesdb")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AddDbContext>();
builder.Services.AddScoped<IVehicleInterface, SqlVehicleRepository>();
builder.Services.AddScoped<IEmployeeInterface, SqlEmployeeRepository>();
builder.Services.AddScoped<IReviewInterface, SqlReviewRepository>();
builder.Services.AddScoped<IRentalInterface, SqlRentalRepository>();
builder.Services.AddScoped<ICarBookingInterface, CarBookingService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
