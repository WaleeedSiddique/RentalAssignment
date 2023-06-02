using RentalAssignment.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.ViewModels
{
    public class VehicleCreateViewModel
    {
        public int VehicleId { get; set; }
        [Required]
        public string VehicleNumberPlate { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleColour { get; set; }
        public string OwnerName { get; set; }
        public string? OwnerPhone { get; set; }
        [Required]
        public string ChassisNumber { get; set; }
        [Required]
        public bool VehicleExistance { get; set; }
        public VehicleType VehicleType { get; set; }
        public IFormFile Photo { get; set; }
    }
}
