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
        public VehicleColour VehicleColour { get; set; }
        public string OwnerName { get; set; }
        [DataType(DataType.Currency)]
        public int RentPerDay { get; set; }

        public string sittingCapacity { get; set; }
        public string? OwnerPhone { get; set; }
        [Required]
        public string ChassisNumber { get; set; }
        [Required]
        public bool VehicleExistance { get; set; }
        public VehicleType VehicleType { get; set; }
        public IFormFile Photo { get; set; }
    }
}
