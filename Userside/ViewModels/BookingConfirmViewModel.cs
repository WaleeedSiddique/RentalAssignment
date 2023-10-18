using Microsoft.AspNetCore.Mvc.Rendering;
using RentalAssignment.Models;
using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.ViewModels
{
    public class BookingConfirmViewModel
    {
        public Rental Booking { get; set; }
        public SelectList? AvailableDrivers { get; set; }

        [Required(ErrorMessage = "Please select a driver")]
        public int SelectedDriverId { get; set; }
        public int RentalID { get; set; }
        
    }
}
