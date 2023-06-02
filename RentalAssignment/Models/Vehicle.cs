using RentalAssignment.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.Models
{
    public class Vehicle
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
        public VehicleType VehicleType { get; set; }
        public string? sittingCapacity { get; set; }
        public string? BikeModel { get; set; }
        public string Photopath { get; set; }
    }
}
