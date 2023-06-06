using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Enums;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;

namespace RentalAssignment.Repository
{
    public class MockVehicleRepository : IVehicleInterface
    {
        private List<Vehicle> _VehicleList;
        public MockVehicleRepository()
        {
            _VehicleList = new List<Vehicle>()
            {
                new Vehicle()  {VehicleId =1 ,OwnerName = "Waleed Siddique",OwnerPhone = "03171215120",VehicleModel = "Suzuki Cultus",VehicleNumberPlate = "KFR-9673",ChassisNumber = "k-356873",VehicleColour = "Silver",VehicleType = VehicleType.Hatchback},
                new Vehicle()  {VehicleId =2 ,OwnerName = "Raheel Izaz",OwnerPhone = "03121325233",VehicleModel = "Audi Etron",VehicleNumberPlate = "E-tron",ChassisNumber = "E-984538",VehicleColour = "Black", VehicleType = VehicleType.Suv},
                new Vehicle()  {VehicleId =3 ,OwnerName = "Kashif Faraz",OwnerPhone = "0316363350",VehicleModel = "Land Cruiser",VehicleNumberPlate = "LFC-2452",ChassisNumber = "L-33523523", VehicleType = VehicleType.Sedan ,VehicleColour = "Gray"},
            };
        }
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            vehicle.VehicleId = _VehicleList.Max(x => x.VehicleId) + 1;
            _VehicleList.Add(vehicle);
            return vehicle;
        }
        

        public Vehicle Delete(int VehicleId)
        {
            var result = _VehicleList.FirstOrDefault(x => x.VehicleId == VehicleId);
            if (result != null)
            {
                _VehicleList.Remove(result);
            }
            return result;
        }


        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _VehicleList.ToList();
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetRentedVehicles()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicle(int Id)
        {

           Vehicle result = _VehicleList.FirstOrDefault(x => x.VehicleId == Id);
            
            return result;
        }

        public Vehicle IsReserved()
        {
            throw new NotImplementedException();
        }

        public Vehicle Update(Vehicle VehicleChanges)
        {
            Vehicle result = _VehicleList.FirstOrDefault(x => x.VehicleId == VehicleChanges.VehicleId);
            if(result != null)
            {
                result.OwnerName = VehicleChanges.OwnerName;
                result.VehicleNumberPlate = VehicleChanges.VehicleNumberPlate;
                result.ChassisNumber = VehicleChanges.ChassisNumber;
                result.VehicleColour = VehicleChanges.VehicleColour;
                result.VehicleModel = VehicleChanges.VehicleModel;
                result.VehicleType = VehicleChanges.VehicleType;
                result.OwnerPhone = VehicleChanges.OwnerPhone;
            }
            return result;
        }

       
    }
}
