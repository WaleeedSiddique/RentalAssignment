using RentalAssignment.Models;
using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.ViewModels
{
    public class VehicleRentalViewModel
    {
        public Vehicle? Vehicle { get; set; }
        public Rental rental { get; set; }
    }

 }

