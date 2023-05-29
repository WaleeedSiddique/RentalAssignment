using RentalAssignment.Models;

namespace RentalAssignment.Interfaces
{
    public interface IBikeInterface
    {
        public Bike GetBike(int BikeeId);
        public Bike CreateBike(Bike bike);
        public IEnumerable<Bike> GetAllBikes();
        public Bike Update(Bike BikeChanges);
        public Bike Delete(int BikeId);
    }
}
