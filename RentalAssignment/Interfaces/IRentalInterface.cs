using Microsoft.VisualBasic;
using RentalAssignment.Enums;
using RentalAssignment.Models;
using static sun.security.provider.NativePRNG;

namespace RentalAssignment.Interfaces
{
    public interface IRentalInterface
    {
        public Rental RentVehicle (Rental rental);
        public Rental DeleteRentedVehicle(int id);
        public Rental GetRentalVehicle(int id);
        public IEnumerable<Rental> GetAllRentalVehicles();
        public Rental UpdateRentalVehicle(Rental rentalChanges);
        public Review AddReview(Review review);
        public IEnumerable<Rental> GetUserBookings(string userId);
        public IEnumerable<Rental> GetAllBookings();
        public Rental GetBookingById(int id);
        public IEnumerable<Rental> GetUnapprovedbookings();
        public IEnumerable<Rental> Getapprovedbookings();
        public void AssignDriverToBooking(int bookingId, int driverId);
        public IEnumerable<Rental> GetByMonth(MonthsEnum month, int year);
        public IEnumerable<Rental> GetByDay(DateTime date);
     




    };
}
