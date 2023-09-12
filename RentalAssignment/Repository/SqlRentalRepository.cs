using Microsoft.EntityFrameworkCore;
using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlRentalRepository : IRentalInterface
    {
        private readonly AddDbContext _context;

        public SqlRentalRepository(AddDbContext context)
        {
            this._context = context;
        }

        public Review AddReview(Review review)
        {
            _context.reviews.Add(review);
            _context.SaveChanges();
            return review;
        }

        

        public Rental DeleteRentedVehicle(int id)
        {
            Rental result = _context.rentals.Find(id);
            if(result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Rental> GetUserBookings(string userId)
        {
            return _context.rentals.Where(x => x.userId == userId);
        }
        public IEnumerable<Rental> GetAllBookings()
        {
            return _context.rentals.ToList();
        }

        public IEnumerable<Rental> GetAllRentalVehicles()
        {
            return _context.rentals;
        }

        public Rental GetBookingById(int id)
        {
            return _context.rentals.FirstOrDefault(b => b.RentalID == id);
        }

        public Rental GetRentalVehicle(int id)
        {
            Rental result = _context.rentals.FirstOrDefault(x => x.RentalID == id);
            return result;
            
        }  

        public Rental RentVehicle(Rental rental)
        {
            _context.rentals.Add(rental);
            _context.SaveChanges();
            return rental;
        }

        public Rental UpdateRentalVehicle(Rental rentalChanges)
        {
            var result = _context.rentals.Attach(rentalChanges);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return rentalChanges;
        }

        public IEnumerable<Rental> GetUnapprovedbookings()
        {
            return _context.rentals.Where(x => x.DriverId == null);
        }
        public IEnumerable<Rental> Getapprovedbookings()
        {
            return _context.rentals.Where(x => x.DriverId != null);
        }
        public void AssignDriverToBooking(int bookingId, int driverId)
        {
            var booking = _context.rentals.Find(bookingId);
            var driver = _context.Employees.Find(driverId);

            if (booking != null && driver != null)
            {
                booking.DriverId = driver.EmployeeId;
                _context.SaveChanges();
            }
        }



    }
}
