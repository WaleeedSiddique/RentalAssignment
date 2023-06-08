using RentalAssignment.Models;

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
    };
}
