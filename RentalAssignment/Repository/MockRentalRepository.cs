using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class MockRentalRepository : IRentalInterface
    {
        private List<Rental> _RentalList;
        public MockRentalRepository()
        {
            _RentalList = new List<Rental>()
            {
                new Rental()  {RentalID = 1,RentalPhone = "03171215120",Dropoff = DateTime.UtcNow, Pickup = DateTime.UtcNow
                },
                new Rental()  {RentalID = 2,RentalPhone = "03171215120",Dropoff = DateTime.UtcNow, Pickup = DateTime.UtcNow},
                new Rental()  {RentalID = 3,RentalPhone = "03171215120",Dropoff = DateTime.UtcNow, Pickup = DateTime.UtcNow},
            };
        }

        public Review AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public void AssignDriverToBooking(int bookingId, int driverId)
        {
            throw new NotImplementedException();
        }

        public Rental DeleteRentedVehicle(int id)
        {
            var result = _RentalList.FirstOrDefault(x => x.RentalID == id);
            if (result != null)
            {
                _RentalList.Remove(result);
            }
            return result;
        }

        public IEnumerable<Rental> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetAllRentalVehicles()
        {
            return _RentalList.ToList();
        }

        public IEnumerable<Rental> Getapprovedbookings()
        {
            throw new NotImplementedException();
        }

        public Rental GetBookingById(int id)
        {
            throw new NotImplementedException();
        }

        public Rental GetRentalVehicle(int id)
        {
            Rental rental = _RentalList.FirstOrDefault(x => x.RentalID == id);
            return rental;
        }

        public IEnumerable<Rental> GetUnApprovedBookings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetUnapprovedbookings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetUserBookings(string userId)
        {
            throw new NotImplementedException();
        }

        public bool IsCarAvailableForBooking(int carId, DateTime pickupDate, DateTime dropoffDate)
        {
            throw new NotImplementedException();
        }

        public Rental RentVehicle(Rental rental)
        {
            rental.RentalID = _RentalList.Max(x => x.RentalID) + 1;
            _RentalList.Add(rental);
            return rental;
        }

        public Rental UpdateRentalVehicle(Rental rentalChanges)
        {
            Rental result = _RentalList.FirstOrDefault(x => x.RentalID == rentalChanges.RentalID);
            if (result != null)
            {                
                result.RentalPhone = rentalChanges.RentalPhone;               
                result.Pickup = rentalChanges.Pickup;
                result.Dropoff = rentalChanges.Dropoff;
            }
            return result;
        }
    }
}
