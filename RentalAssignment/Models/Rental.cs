using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentalAssignment.Models
{
    public class Rental
    {
        public int RentalID { get; set; }
        public string userId { get; set; }
        public int VehicleID { get; set; }
        public Vehicle vehicle { get; set; }
        [Required]
        public string RentalName { get; set; } = "Waleed";
        [Required]
        [MaxLength(11)]
        public string RentalPhone { get; set; }
        public string RentalEmail { get; set; } = "Waleed@gmail.com";
        [Required]
        public DateTime Pickup { get; set; }
        [Required]
        public DateTime Dropoff { get; set; }
        public string pickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public bool BookingStatus { get; set; }
        public int? employeeid { get; set; }
        public Employee? employee { get; set; }

        public Rental()
        {
            Pickup = DateTime.Now;
            Dropoff = DateTime.Now;
        }
    }
}
