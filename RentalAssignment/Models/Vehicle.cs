using RentalAssignment.Enums;
using System.ComponentModel.DataAnnotations;
using static sun.security.provider.NativePRNG;

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
        [MaxLength(11)]
        public string? OwnerPhone { get; set; }
        [Required]
        public string ChassisNumber { get; set; }
        [Required]
        public VehicleType VehicleType { get; set; }
        public string? sittingCapacity { get; set; }
        public string? BikeModel { get; set; }
        public string Photopath { get; set; }
        [DataType(DataType.Currency)]
        public string RentPerDay { get; set; } = "2,000";
        public ICollection<Rental> Bookings { get; set; }

        public bool IsRented { get; set; }
     
       
    }
}
