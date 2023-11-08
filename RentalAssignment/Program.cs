using LibGit2Sharp;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
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
builder.Services.AddScoped<IContactInterface, SqlContactRepository>();
builder.Services.AddScoped<ICarBookingInterface, CarBookingService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVehicleCategoryInterface, SqlVehicleCategoryRepository>();
builder.Services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = "806082718120-i4qecnuq5nc8qib1pq36cqimj0u5cjdh.apps.googleusercontent.com";
    options.ClientSecret = "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";
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
         Path.Combine(Directory.GetCurrentDirectory(), "../AdminPanel/wwwroot", @"Images")),
    RequestPath = new PathString("/Images")
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
