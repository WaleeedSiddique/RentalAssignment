using com.sun.xml.@internal.bind.v2.model.core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalAssignment.Dto;
using RentalAssignment.Enums;
using RentalAssignment.Interfaces;
using RentalAssignment.Migrations;
using RentalAssignment.Models;
using RentalAssignment.Repository;
using RentalAssignment.ViewModels;
using sun.security.x509;
using System.Security.Claims;

namespace RentalAssignment.Controllers
{
    public class RentalController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeInterface _employeeInterface;
        private readonly IRentalInterface _rentalInterface;
        private readonly IVehicleInterface _vehicleInterface;
        private readonly ICarBookingInterface _bookingService;

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User); public RentalController(IRentalInterface rentalInterface, IVehicleInterface vehicleInterface, ICarBookingInterface bookingService, UserManager<ApplicationUser> userManager, IEmployeeInterface employeeInterface)
        {
            this._rentalInterface = rentalInterface;
            this._vehicleInterface = vehicleInterface;
            this._bookingService = bookingService;
            this._userManager = userManager;
            this._employeeInterface = employeeInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _rentalInterface.GetAllRentalVehicles();
            return View(model);

        }
        [HttpGet]
        public IActionResult Booking(int id)
        {
            Vehicle vehicle = _vehicleInterface.GetVehicle(id);
            BookingDto bookingDto = new BookingDto
            {
                VehicleId = vehicle.VehicleId,
                ChassisNumber = vehicle.ChassisNumber,
                VehicleNumberPlate = vehicle.VehicleNumberPlate,
                VehicleModel = vehicle.VehicleModel,
                VehicleColour = vehicle.VehicleColour,
                OwnerName = vehicle.OwnerName,
                OwnerPhone = vehicle.OwnerPhone,
                VehicleType = vehicle.VehicleType,
                sittingCapacity = vehicle.sittingCapacity,
                Photopath = vehicle.Photopath,
                RentPerDay = vehicle.RentPerDay,
                IsRented = vehicle.IsRented,
            };

            return View(bookingDto);

        }
        [HttpPost]
        [Authorize]
        public IActionResult Booking(BookingDto bookingDto)
        {
            if (ModelState.IsValid) {

                if (_bookingService.IsCarAvailableForBooking(bookingDto.VehicleId, bookingDto.Pickup, bookingDto.Dropoff))
                {

                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    // var user = GetCurrentUserAsync();
                    //    var userId = user?.Id;
                    Rental rental = new Rental
                    {
                        RentalName = bookingDto.RentalName,
                        RentalPhone = bookingDto.RentalPhone,
                        RentalEmail = bookingDto.RentalEmail,
                        Dropoff = bookingDto.Dropoff,
                        DropoffLocation = bookingDto.DropoffLocation,
                        pickupLocation = bookingDto.pickupLocation,
                        Pickup = bookingDto.Pickup,
                        VehicleID = bookingDto.VehicleId,
                        userId = userId

                    };
                    var car = _vehicleInterface.GetVehicle(bookingDto.VehicleId);
                    car.IsRented = true;
                    Rental model = _rentalInterface.RentVehicle(rental);
                    return RedirectToAction("Index", new { model.RentalID });
                }
                else
                {
                    ViewBag.message = "Car is already booked for the specified date range";
                    return View();
                }
            }
            ViewBag.message = "Something went wrong kindly check again";
            return View();
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
            if (result != null)
            {
                EditRentalViewModel editRentalViewModel = new EditRentalViewModel
                { RentalName = result.RentalName,
                    RentalEmail = result.RentalEmail,
                    RentalPhone = result.RentalPhone,
                    Pickup = result.Pickup,
                    pickupLocation = result.pickupLocation,
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
                result.RentalPhone = model.RentalPhone;
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
        public IActionResult Review()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Review(ReviewViewModel model)
        {

            Review result = new Review
            {
                Rating = model.Rating,
                Comment = model.Comment,
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            Review newReview = _rentalInterface.AddReview(result);
            return RedirectToAction("Home", new { newReview.Id });

        }

        public IActionResult MyBookings()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);


            IEnumerable<Rental> userBookings = _rentalInterface.GetUserBookings(userId);
            return View(userBookings);
        }
        [HttpGet]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _rentalInterface.GetBookingById(id);
            var car = _vehicleInterface.GetVehicle(booking.VehicleID);
            if (booking != null)
            {
                car.IsRented = false;
                _rentalInterface.DeleteRentedVehicle(id);
                return RedirectToAction("MyBookings");
            }
            else
            {
                ViewBag.message = "Could not be deleted";
                return RedirectToAction("MyBookings");
            }

        }
        
        //public IActionResult PendingBookings()
        //{
        //   // var bookings = _rentalInterface.GetUnApprovedBookings();
        //   // return View(bookings);
        //}



    }

}