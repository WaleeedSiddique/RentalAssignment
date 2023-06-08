using com.sun.xml.@internal.bind.v2.model.core;
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
        public IActionResult Vehicle(VehicleRentalViewModel vehicleRentalViewModel)
        {                       
                Rental rental = new Rental
                {
                    RentalName = vehicleRentalViewModel.rental.RentalName,
                    RentalPhone = vehicleRentalViewModel.rental.RentalPhone,
                    RentalEmail = vehicleRentalViewModel.rental.RentalEmail,
                    Dropoff = vehicleRentalViewModel.rental.Dropoff,
                    DropoffLocation = vehicleRentalViewModel.rental.DropoffLocation,
                    pickupLocation = vehicleRentalViewModel.rental.pickupLocation,
                    Pickup = vehicleRentalViewModel.rental.Pickup

                };
                Rental model = _rentalInterface.RentVehicle(rental);
                return RedirectToAction("Review", new { model.RentalID });
            
        }
        [HttpGet]
        public IActionResult RentedVehicles()
        {
            var model = _rentalInterface.GetAllRentalVehicles();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Rental result = _rentalInterface.GetRentalVehicle(id);
            if(result != null)
            {
                EditRentalViewModel editRentalViewModel = new EditRentalViewModel
                {
                    RentalName=result.RentalName,
                    RentalPhone=result.RentalPhone,
                    RentalEmail=result.RentalEmail,
                    Pickup = result.Pickup,
                    pickupLocation =result.pickupLocation,
                    Dropoff = result.Dropoff,
                    DropoffLocation = result.DropoffLocation,                    
                };
                return View(editRentalViewModel);
            }
            return NotFound("Rental Not Found"); //404 error
        }
        [HttpPost]
        public IActionResult Edit(EditRentalViewModel model)
        {
            Rental result = _rentalInterface.GetRentalVehicle(model.id);
            if (ModelState.IsValid)
            {
                result.RentalName = model.RentalName;
                result.RentalPhone = model.RentalPhone;
                result.RentalEmail = model.RentalEmail;
                result.Pickup = model.Pickup;
                result.pickupLocation = model.pickupLocation;
                result.Dropoff = model.Dropoff;
                result.DropoffLocation = model.DropoffLocation;
                result.VehicleID = model.VehicleID;
                Rental Updatedrental = _rentalInterface.UpdateRentalVehicle(result);
                return RedirectToAction("Index");
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _rentalInterface.DeleteRentedVehicle(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Review(int rentalid)
        {
            var result = _rentalInterface.GetRentalVehicle(rentalid);
            if(result == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Review(ReviewViewModel model)
        {
            
                Review result = new Review
                {
                    Rating = model.Rating,
                    Comment = model.Comment
                };
                  _rentalInterface.AddReview(result);
                    return RedirectToAction("index");            
            
        }
    }
}
