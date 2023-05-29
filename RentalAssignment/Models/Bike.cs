using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.Models
{
    public class Bike
    {
        public int BikeId { get; set; }
        public string BikeModel { get; set; }
        public string sittingCapacity { get; set; }
        public string BikeEngine { get; set; }
        public string OwnerName { get; set; }
        public string BikeColour { get; set; }
        [Required]
        public string ChassisNumber { get; set; }
        public string OwnerPhone { get; set; }
        [Required]
        public string BikeNumberPlate { get; set; }


    }
}
