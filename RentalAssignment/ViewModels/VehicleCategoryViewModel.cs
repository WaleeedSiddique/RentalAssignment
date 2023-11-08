using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.ViewModels
{
    public class VehicleCategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
