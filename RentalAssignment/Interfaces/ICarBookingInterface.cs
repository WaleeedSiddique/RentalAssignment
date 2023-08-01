using RentalAssignment.Models;

namespace RentalAssignment.Interfaces
{
    public interface ICarBookingInterface
    {       
        public bool IsCarAvailableForBooking(int carId, DateTime startDate, DateTime endDate);
    }
}
