using RentalAssignment.Models;
using RentalAssignment.ViewModels;

namespace RentalAssignment.Interfaces
{
    public interface IVehicleInterface
    {
        public Vehicle GetVehicle(int vehicleId);
        public IEnumerable<Vehicle> SearchVehicles(string VehicleName);
        public Vehicle CreateVehicle(Vehicle vehicle);
        public IEnumerable<Vehicle> GetAllVehicles();
        public Vehicle Update(Vehicle VehicleChanges);
        public Vehicle Delete(int VehicleId);
        public List<Vehicle> GetAvailableVehicles();
        public List<Vehicle> GetRentedVehicles();  
       public IEnumerable<Vehicle> GetNotRentedVehicles(DateTime pickup,DateTime dropoff);
        
    }
}
