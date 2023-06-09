using RentalAssignment.Models;

namespace RentalAssignment.ViewModels
{
    public class ReviewViewModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Rental rental { get; set; }
    }
}
