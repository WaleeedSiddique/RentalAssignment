using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentalAssignment.Enums;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;
using System.Diagnostics;

namespace RentalAssignment.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IVehicleInterface _vehicleInterface;

        public HomeController(IVehicleInterface vehicleInterface)
        {
           
            this._vehicleInterface = vehicleInterface;
        }

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
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
            Vehicle model = _vehicleInterface.CreateVehicle(vehicle);
            return RedirectToAction("Index", new {model.VehicleId});

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
            if (ModelState.IsValid) {
                Vehicle result = _vehicleInterface.GetVehicle(model.VehicleId);
                
                Vehicle newVehicle = new Vehicle()
                {
                 OwnerName = model.OwnerName,
                 VehicleColour= model.VehicleColour,
                 VehicleModel= model.VehicleModel,
                 VehicleNumberPlate= model.VehicleNumberPlate,
                 VehicleType= model.VehicleType,
                 ChassisNumber= model.ChassisNumber,
                };

                _vehicleInterface.CreateVehicle(newVehicle);
                return RedirectToAction("Details", new {id = newVehicle.VehicleId});
            }
            return View();

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            _vehicleInterface.Delete(id);
                return RedirectToAction("Index");
            
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