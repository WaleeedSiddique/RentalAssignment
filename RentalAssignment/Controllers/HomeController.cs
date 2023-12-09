using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentalAssignment.DatabaseContext;
using RentalAssignment.Enums;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.Repository;
using RentalAssignment.ViewModels;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RentalAssignment.Controllers
{
    public class HomeController : Controller
    {

        private readonly IVehicleInterface _vehicleInterface;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly AddDbContext _context;
        private readonly IVehicleCategoryInterface _vehicleCategory;

        public HomeController(IVehicleInterface vehicleInterface, IHostingEnvironment hostingEnvironment,AddDbContext context,IVehicleCategoryInterface vehicleCategory)
        {

            this._vehicleInterface = vehicleInterface;
            this.hostingEnvironment = hostingEnvironment;
            this._context = context;
            this._vehicleCategory = vehicleCategory;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            
            var model = _vehicleInterface.GetAllVehicles();
            return View(model);
            
        }

        public IActionResult Search(string VehicleName)
        {
            if(VehicleName != null)
            {
                var cars = _vehicleInterface.GetAllVehicles().ToList();
                //return View(cars)
                    return RedirectToAction("SearchPage");
            }
            ViewBag.message = "This Car is not available, You can search other cars";
            return RedirectToAction("SearchPage");
        }
        [HttpGet]
        public IActionResult SearchPage()
        {
            var availablecars = _vehicleInterface.GetAllVehicles();                             
            return View(availablecars);
        }
        [HttpPost]
        public IActionResult SearchPage(DateTime pickup, DateTime dropoff)
        {
            var availablecars = _vehicleInterface.GetAllVehicles();
            if (availablecars != null)
            {
                availablecars = _vehicleInterface.GetNotRentedVehicles(pickup, dropoff);
            }
            return View(availablecars);
        }
        //[HttpPost]
        //public IActionResult GetAvailableCars(DateTime pickup, DateTime dropoff)
        //{
        //    var availablecars = _vehicleInterface.GetAllVehicles();
        //    if(availablecars != null)
        //    {
        //     availablecars = _vehicleInterface.GetNotRentedVehicles(pickup, dropoff);
        //    }
        //        return View(availablecars);

        //}
        //[HttpPost]
        //public IActionResult Index(string SearchText)
        //{
        //    var users = _context.vehicles.ToList();
        //    if (SearchText != null)
        //    {
        //        users = _context.vehicles.Where(x => x.VehicleModel.Contains(SearchText)).ToList();
        //    }
        //    return View(users);
        //}
        [Route("Home/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            var model = _vehicleInterface.GetVehicle(id ?? 1);
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var Categories = _vehicleCategory.GetAllCategories();
            ViewBag.category = new SelectList(Categories, "CategoryId", "CategoryName");
          
            return View();
        }
        private bool IsImageFileValid(IFormFile file)
        {
            // Check the file extension against the allowed extensions
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            string fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            return allowedExtensions.Contains(fileExtension);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(VehicleCreateViewModel vehicle)
        {

            if (ModelState.IsValid)
            {
                if (vehicle.OwnerPhone.Contains("-"))
                {
                    ViewBag.message = "Phone number should not contain dash";
                    return View();
                }
                string uniqueFileName = null;
                if (vehicle.Photo != null)
                {
                    if (!IsImageFileValid(vehicle.Photo))
                    {
                        ViewBag.message = "Car ImageFile Invalid file format. Only JPG, JPEG, and PNG files are allowed.";
                        return View(vehicle);
                    }                    
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath,"images");
                    uniqueFileName = Guid.NewGuid().ToString()+ "_" +vehicle.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    vehicle.Photo.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                Vehicle newVehicle = new Vehicle
                {
                    OwnerName = vehicle.OwnerName,
                    OwnerPhone = vehicle.OwnerPhone,
                    VehicleColour = vehicle.VehicleColour,
                    VehicleModel = vehicle.VehicleModel,
                    VehicleNumberPlate = vehicle.VehicleNumberPlate,
                    VehicleType = vehicle.VehicleType,
                    ChassisNumber = vehicle.ChassisNumber,
                    RentPerDay = vehicle.RentPerDay,
                    sittingCapacity = vehicle.sittingCapacity,
                    VehicleCategoryId = vehicle.VehicleCategoryId,
                    Photopath = uniqueFileName
                };
                Vehicle vehicle1 = _vehicleInterface.CreateVehicle(newVehicle);

                return RedirectToAction("Details", new { id = vehicle1.VehicleId });

            }
            return View();

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {

            Vehicle result = _vehicleInterface.GetVehicle(id);
            EditVehicleViewModel editVehicleViewModel = new EditVehicleViewModel
            {
                OwnerName = result.OwnerName,
                OwnerPhone = result.OwnerPhone,
                ChassisNumber = result.ChassisNumber,
                VehicleColour = result.VehicleColour,
                sittingCapacity = result.sittingCapacity,
                VehicleModel = result.VehicleModel,
                VehicleNumberPlate = result.VehicleNumberPlate,
                VehicleType = result.VehicleType,
                RentPerDay = result.RentPerDay

            };
            return View(editVehicleViewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(EditVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photopath != null)
                {
                    if (!IsImageFileValid(model.Photopath))
                    {
                        ViewBag.message = "Car ImageFile Invalid file format. Only JPG, JPEG, and PNG files are allowed.";
                        return View(model);
                    }
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photopath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photopath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Vehicle result = _vehicleInterface.GetVehicle(model.id);
                if (result != null)
                {
                    result.OwnerName = model.OwnerName;
                    result.VehicleColour = model.VehicleColour;
                    result.VehicleModel = model.VehicleModel;
                    result.sittingCapacity = model.sittingCapacity;
                    result.VehicleNumberPlate = model.VehicleNumberPlate;
                    result.VehicleType = model.VehicleType;
                    result.RentPerDay = model.RentPerDay;
                    result.ChassisNumber = model.ChassisNumber;
                    result.Photopath = uniqueFileName;
                    Vehicle UpdatedVehicle = _vehicleInterface.Update(result);
                    return RedirectToAction("Details", new { id = UpdatedVehicle.VehicleId });
                }
                return View(model);
            }
            return View(model);

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            var model = _vehicleInterface.Delete(id);
            return RedirectToAction("Index");

        }
        public IActionResult AvailableCars()
        {
            List<Vehicle> availableCars = _vehicleInterface.GetAvailableVehicles();
            return View(availableCars);
        }

        public IActionResult RentedCars()
        {
            List<Vehicle> rentedCars = _vehicleInterface.GetRentedVehicles();
            return View(rentedCars);
        }
        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            var Vehicles = _vehicleInterface.GetAllVehiclesWithCategory();
            return View(Vehicles);
        }
        [HttpGet]
        public IActionResult GetBudgetVehicles()
        {
            var vehicles = _vehicleInterface.GetAllVehicles().Where(x => x.VehicleCategory.CategoryName == "Budget");
            return View("SearchPage",vehicles);
        }
        [HttpGet]
        public IActionResult GetStandardVehicles()
        {
            var vehicles = _vehicleInterface.GetAllVehicles().Where(x => x.VehicleCategory.CategoryName == "Standard");
            return View("SearchPage", vehicles);
        }
        [HttpGet]
        public IActionResult GetLuxuryVehicles()
        {
            var vehicles = _vehicleInterface.GetAllVehicles().Where(x => x.VehicleCategory.CategoryName == "Luxury");
            return View("SearchPage", vehicles);
        }
        [HttpGet]
        public IActionResult GetVansVehicles()
        {
            var vehicles = _vehicleInterface.GetAllVehicles().Where(x => x.VehicleCategory.CategoryName == "Vans");
            return View("SearchPage", vehicles);
        }
        [HttpGet]
        public IActionResult GetSUVVehicles()
        {
            var vehicles = _vehicleInterface.GetAllVehicles().Where(x => x.VehicleCategory.CategoryName == "SUV");
            return View("SearchPage", vehicles);
        }
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}