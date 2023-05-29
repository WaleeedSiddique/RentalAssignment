using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlBikeRepository : IBikeInterface
    {
        private readonly AddDbContext _context;

        public SqlBikeRepository(AddDbContext context)
        {
            this._context = context;
        }
        public Bike CreateBike(Bike bike)
        {
            _context.Bikes.Add(bike);
            _context.SaveChanges();
            return bike;

        }

        public Bike Delete(int BikeId)
        {
            var result = _context.Bikes.Find(BikeId);
            if (result != null)
            {
                _context.Bikes.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Bike> GetAllBikes()
        {
            return _context.Bikes;
        }

        public Bike GetBike(int id)
        {
            var model = _context.Bikes.FirstOrDefault(x => x.BikeId == id);
            return model;
        }

        public Bike Update(Bike BikeChanges)
        {
            var result = _context.Bikes.Attach(BikeChanges);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return BikeChanges;
        }
    }
}
