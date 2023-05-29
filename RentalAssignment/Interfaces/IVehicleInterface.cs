using RentalAssignment.Models;

namespace RentalAssignment.Interfaces
{
    public interface IVehicleInterface
    {
        public Vehicle GetVehicle(int vehicleId);
        public Vehicle CreateVehicle(Vehicle vehicle);
        public IEnumerable<Vehicle> GetAllVehicles();
        public Vehicle Update(Vehicle VehicleChanges);
        public Vehicle Delete(int VehicleId);
    }
}
