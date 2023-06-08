using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.Models
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int VehicleID { get; set; }
        [Required]
        public string RentalName { get; set; }
        [Required]
        public string RentalPhone { get; set; }
        public string RentalEmail { get; set; }
        [Required]
        public DateTime Pickup { get; set; }
        [Required]
        public DateTime Dropoff { get; set; }
        public string pickupLocation { get; set; }
        public string DropoffLocation { get; set; }       

    }
}
