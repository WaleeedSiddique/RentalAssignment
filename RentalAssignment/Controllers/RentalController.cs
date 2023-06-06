using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;

namespace RentalAssignment.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalInterface _rentalInterface;
        private readonly IVehicleInterface _vehicleInterface;

        public RentalController(IRentalInterface rentalInterface, IVehicleInterface vehicleInterface)
        {
            this._rentalInterface = rentalInterface;
            this._vehicleInterface = vehicleInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _rentalInterface.GetAllRentalVehicles();
            return View(model);
            
        }
        [HttpGet]
        public IActionResult Vehicle(int id)
        {
            Vehicle result = _vehicleInterface.GetVehicle(id);
            VehicleRentalViewModel vehicleRentalViewModel = new VehicleRentalViewModel
            {
                Vehicle= result,

            };

            
            return View(vehicleRentalViewModel);

        }
        [HttpPost]
        [Authorize]
        public IActionResult Vehicle(Rental rental)
        {
            if (ModelState.IsValid)
            {
                Rental model = _rentalInterface.RentVehicle(rental);
                return RedirectToAction("Index", new { model.RentalID });

            }
            return View();
        }
        public IActionResult RentedVehicles()
        {
            var model = _rentalInterface.GetAllRentalVehicles();
            return View(model);
        }
    }
}
