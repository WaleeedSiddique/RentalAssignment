using RentalAssignment.Models;

namespace RentalAssignment.Interfaces
{
    public interface IVehicleCategoryInterface
    {
        VehicleCategory GetCategoryById(int id);
        IEnumerable<VehicleCategory> GetAllCategories();
        void AddCategory(VehicleCategory category);
        void RemoveCategory(int id);
        void UpdateCategory(VehicleCategory EmployeeChanges);
    }
}
