using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlVehicleRepository : IVehicleInterface
    {
        private readonly AddDbContext _context;

        public SqlVehicleRepository(AddDbContext context)
        {
            this._context = context;
        }
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            _context.vehicles.Add(vehicle);
            _context.SaveChanges();
            return vehicle;
            
        }

        public Vehicle Delete(int VehicleId)
        {
            var result =_context.vehicles.Find(VehicleId);
            if(result != null)
            {
                 _context.vehicles.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _context.vehicles;
        }

        public Vehicle GetVehicle(int id)
        {
            var model = _context.vehicles.FirstOrDefault(x => x.VehicleId == id);
            return model;
        }

        public Vehicle Update(Vehicle VehicleChanges)
        {
            var result = _context.vehicles.Attach(VehicleChanges);
            result.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return VehicleChanges;
        }
    }
}
