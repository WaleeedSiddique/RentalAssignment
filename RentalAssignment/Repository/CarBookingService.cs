using Microsoft.EntityFrameworkCore;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class CarBookingService :ICarBookingInterface
    {
        private readonly IVehicleInterface _vehicleInterface;
        private readonly IRentalInterface _rentalInterface;

        public CarBookingService(IVehicleInterface vehicleInterface,IRentalInterface rentalInterface)
        {
            this._vehicleInterface = vehicleInterface;
            this._rentalInterface = rentalInterface;
        }
        public bool IsCarAvailableForBooking(int carId, DateTime startDate, DateTime endDate)
        {
            var car = _vehicleInterface.GetVehicle(carId);

            if (car != null)
            {
                var overlappingBookings = _rentalInterface.GetAllBookings()
                    .Where(b => b.VehicleID == carId &&
                                !(b.Dropoff <= startDate || b.Pickup >= endDate))
                    .ToList();

                return overlappingBookings.Count == 0;
            }

            return false;
        }

        

        // Other methods for booking cars, saving bookings, etc.
    }
}

