using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public HomeController(IVehicleInterface vehicleInterface, IHostingEnvironment hostingEnvironment)
        {

            this._vehicleInterface = vehicleInterface;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _vehicleInterface.GetAllVehicles();
            return View(model);
        }
        [Route("Home/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            var model = _vehicleInterface.GetVehicle(id ?? 1);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VehicleCreateViewModel vehicle)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (vehicle.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + vehicle.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    vehicle.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
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
                    Photopath = uniqueFileName
                };
                Vehicle vehicle1 = _vehicleInterface.CreateVehicle(newVehicle);

                return RedirectToAction("Details", new { id = vehicle1.VehicleId });

            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Vehicle result = _vehicleInterface.GetVehicle(id);
            EditVehicleViewModel editVehicleViewModel = new EditVehicleViewModel
            {
                OwnerName = result.OwnerName,
                ChassisNumber = result.ChassisNumber,
                VehicleColour = result.VehicleColour,
                VehicleModel = result.VehicleModel,
                VehicleNumberPlate = result.VehicleNumberPlate,
                VehicleType = result.VehicleType,

            };
            return View(editVehicleViewModel);
        }


        [HttpPost]
        public IActionResult Edit(EditVehicleViewModel model)
        {

            Vehicle result = _vehicleInterface.GetVehicle(model.id);
            if (ModelState.IsValid)
            {
                result.OwnerName = model.OwnerName;
                result.VehicleColour = model.VehicleColour;
                result.VehicleModel = model.VehicleModel;
                result.VehicleNumberPlate = model.VehicleNumberPlate;
                result.VehicleType = model.VehicleType;
                result.ChassisNumber = model.ChassisNumber;
                Vehicle UpdatedVehicle = _vehicleInterface.Update(result);
                return RedirectToAction("Index");
            }
            return View(model);

        }
        [HttpGet]
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