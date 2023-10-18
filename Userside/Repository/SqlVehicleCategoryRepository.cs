using org.omg.CosNaming.NamingContextPackage;
using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlVehicleCategoryRepository : IVehicleCategoryInterface
    {
        private readonly AddDbContext _context;

        public SqlVehicleCategoryRepository(AddDbContext context)
        {
            this._context = context;
        }

        public void AddCategory(VehicleCategory category)
        {
            var model = _context.VehicleCategories.Add(category);
            _context.SaveChanges();
        }

        public IEnumerable<VehicleCategory> GetAllCategories()
        {

            return _context.VehicleCategories;
             
        }

        public VehicleCategory GetCategoryById(int id)
        {
            var model = _context.VehicleCategories.FirstOrDefault(x => x.Id == id);
            return model;
        }

        public void RemoveCategory(int id)
        {
            var model = _context.VehicleCategories.Find(id);
            if(model != null)
            {                
            _context.VehicleCategories.Remove(model);
            _context.SaveChanges();
                
            }
           

        }

        public void UpdateCategory(VehicleCategory EmployeeChanges)
        {
            var model = _context.VehicleCategories.Attach(EmployeeChanges);
            model.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
