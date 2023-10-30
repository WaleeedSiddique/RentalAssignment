using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.Models
{
    public class VehicleCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Vehicle> vehicles { get; set; }
    }
}
