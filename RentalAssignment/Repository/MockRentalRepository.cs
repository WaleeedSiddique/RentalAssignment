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
                new Rental()  {RentalID = 1,RentalName = "Waleed Siddique" , RentalEmail = "Waleed@gmail.com",RentalPhone = "03171215120",Dropoff = DateTime.UtcNow, Pickup = DateTime.UtcNow
                },
                new Rental()  {RentalID = 2,RentalName = "Raheel Izaz" , RentalEmail = "Raheel@gmail.com",RentalPhone = "03171215120",Dropoff = DateTime.UtcNow, Pickup = DateTime.UtcNow},
                new Rental()  {RentalID = 3,RentalName = "Ahmed Khan" , RentalEmail = "Ahmed@gmail.com",RentalPhone = "03171215120",Dropoff = DateTime.UtcNow, Pickup = DateTime.UtcNow},
            };
        }

        public Review AddReview(Review review)
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

        public IEnumerable<Rental> GetAllRentalVehicles()
        {
            return _RentalList.ToList();
        }

        public Rental GetRentalVehicle(int id)
        {
            Rental rental = _RentalList.FirstOrDefault(x => x.RentalID == id);
            return rental;
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
                result.RentalName = rentalChanges.RentalName;
                result.RentalPhone = rentalChanges.RentalPhone;
                result.RentalEmail = rentalChanges.RentalEmail;
                result.Pickup = rentalChanges.Pickup;
                result.Dropoff = rentalChanges.Dropoff;
            }
            return result;
        }
    }
}
