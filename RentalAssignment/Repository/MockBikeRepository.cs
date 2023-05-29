using RentalAssignment.Enums;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class MockBikeRepository : IBikeInterface 
    {
        private List<Bike> _BikeList;
        public MockBikeRepository()
        {
            _BikeList = new List<Bike>()
            {
                new Bike()  {BikeId =1 ,OwnerName = "Waleed Siddique",OwnerPhone = "03171215120",BikeModel = "Yamaha",BikeNumberPlate = "KFR-9673",ChassisNumber = "k-356873",BikeColour = "Silver",sittingCapacity = "2",BikeEngine = "1000cc"},
                new Bike()  {BikeId =2 ,OwnerName = "Raheel Izaz",OwnerPhone = "03121325233",BikeModel = "Honda",BikeNumberPlate = "Hayabusa",ChassisNumber = "E-984538",BikeColour = "Black",sittingCapacity = "2",BikeEngine = "1500cc"},
                new Bike()  {BikeId =3 ,OwnerName = "Kashif Faraz",OwnerPhone = "0316363350",BikeModel = "Honda",BikeNumberPlate = "LFC-2452",ChassisNumber = "L-33523523",BikeColour = "Gray",sittingCapacity = "2",BikeEngine = "2000cc"},
            };
        }
        public Bike CreateBike(Bike bike)
        {
            bike.BikeId = _BikeList.Max(x => x.BikeId) + 1;
            _BikeList.Add(bike);
            return bike;
        }

        public Bike Delete(int VehicleId)
        {
            var result = _BikeList.FirstOrDefault(x => x.BikeId == VehicleId);
            if (result != null)
            {
                _BikeList.Remove(result);
            }
            return result;
        }


        public IEnumerable<Bike> GetAllBikes()
        {
            return _BikeList.ToList();
        }

        public Bike GetBike(int Id)
        {

            Bike result = _BikeList.FirstOrDefault(x => x.BikeId == Id);

            return result;
        }

        public Bike Update(Bike BikeChanges)
        {
            Bike result = _BikeList.FirstOrDefault(x => x.BikeId == BikeChanges.BikeId);
            if (result != null)
            {
                result.OwnerName = BikeChanges.OwnerName;
                result.BikeNumberPlate = BikeChanges.BikeNumberPlate;
                result.ChassisNumber = BikeChanges.ChassisNumber;
                result.BikeColour = BikeChanges.BikeColour;
                result.BikeModel = BikeChanges.BikeModel;
                result.OwnerPhone = BikeChanges.OwnerPhone;
            }
            return result;
        }
    }
}
