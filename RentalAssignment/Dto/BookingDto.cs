using RentalAssignment.Enums;
using RentalAssignment.Models;
using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.Dto
{
    public class BookingDto
    {
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public string RentalName { get; set; } 
        [Required]
        [MaxLength(11)]
        public string RentalPhone { get; set; }
        public string RentalEmail { get; set; } 
        [Required]
        public DateTime Pickup { get; set; }
        [Required]
        public DateTime Dropoff { get; set; }
        public string pickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        
        public string VehicleNumberPlate { get; set; }
        public string? VehicleModel { get; set; }
        public VehicleColour VehicleColour { get; set; }
        public string OwnerName { get; set; }
        public string? OwnerPhone { get; set; }
        public string ChassisNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public string? sittingCapacity { get; set; }
        public string? Photopath { get; set; }
        [DataType(DataType.Currency)]
        public int RentPerDay { get; set; }
        public bool IsRented { get; set; }


    }
}
