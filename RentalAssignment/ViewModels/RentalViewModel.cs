﻿namespace RentalAssignment.ViewModels
{
    public class RentalViewModel
    {
        public int RentalID { get; set; }
        public int VehicleID { get; set; }      
        public string RentalPhone { get; set; }        
        public DateTime Pickup { get; set; }
        public DateTime Dropoff { get; set; }
        public string pickupLocation { get; set; }
        public string DropoffLocation { get; set; }
      
    }
}
