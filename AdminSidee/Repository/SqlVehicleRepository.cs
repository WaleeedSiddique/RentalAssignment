using Microsoft.AspNetCore.Mvc;
using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;
using System.Web.WebPages;

namespace RentalAssignment.Repository
{
    public class SqlVehicleRepository : IVehicleInterface
    {
        private readonly AddDbContext _context;

        public SqlVehicleRepository(AddDbContext context)
        {
            this._context = context;
        }
      
        public  Vehicle CreateVehicle(Vehicle vehicle)
        {
            
                _context.vehicles.Add(vehicle);
                _context.SaveChanges();
                return vehicle;
           
           
        }

        public Vehicle Delete(int VehicleId)
        {
            Vehicle result =_context.vehicles.Find(VehicleId);
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

        public List<Vehicle> GetAvailableVehicles()
        {
            return _context.vehicles.Where(c => !c.IsRented).ToList();
        }

        public IEnumerable<Vehicle> GetNotRentedVehicles(DateTime startDate,DateTime endDate)
        {
            var cars = _context.vehicles.Where(x => !x.Bookings.Any(b =>
            (b.Dropoff >= startDate && b.Pickup <= endDate))).ToList();
            return cars;
        }

        public List<Vehicle> GetRentedVehicles()
        {
            return _context.vehicles.Where(c => c.IsRented).ToList();
        }

        public Vehicle GetVehicle(int id)
        {
            var model = _context.vehicles.FirstOrDefault(x => x.VehicleId == id);
            return model;
        }

        public IEnumerable<Vehicle> SearchVehicles(string VehicleName)
        {
            var car = _context.vehicles.Where(x => x.VehicleModel.Contains(VehicleName));
            return car;
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
