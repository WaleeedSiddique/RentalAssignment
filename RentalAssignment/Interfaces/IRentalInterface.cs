﻿using Microsoft.VisualBasic;
using RentalAssignment.Models;
using static sun.security.provider.NativePRNG;

namespace RentalAssignment.Interfaces
{
    public interface IRentalInterface
    {
        public Rental RentVehicle (Rental rental);
        public Rental DeleteRentedVehicle(int id);
        public Rental GetRentalVehicle(int id);
        public IEnumerable<Rental> GetAllRentalVehicles();
        public Rental UpdateRentalVehicle(Rental rentalChanges);
        public Review AddReview(Review review);
        public IEnumerable<Rental> GetAllBookings();
        public Rental GetBookingById(int id);

        
    };
}
