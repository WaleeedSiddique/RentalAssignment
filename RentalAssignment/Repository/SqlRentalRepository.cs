﻿using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlRentalRepository : IRentalInterface
    {
        private readonly AddDbContext _context;

        public SqlRentalRepository(AddDbContext context)
        {
            this._context = context;
        }

        public Review AddReview(Review review)
        {
            _context.reviews.Add(review);
            _context.SaveChanges();
            return review;
        }

        public Rental DeleteRentedVehicle(int id)
        {
            Rental result = _context.rentals.Find(id);
            if(result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Rental> GetAllRentalVehicles()
        {
            return _context.rentals;
        }

        public Rental GetRentalVehicle(int id)
        {
            Rental result = _context.rentals.FirstOrDefault(x => x.RentalID == id);
            return result;
            
        }

        public Rental RentVehicle(Rental rental)
        {
            _context.rentals.Add(rental);
            _context.SaveChanges();
            return rental;
        }

        public Rental UpdateRentalVehicle(Rental rentalChanges)
        {
            var result = _context.rentals.Attach(rentalChanges);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return rentalChanges;
        }
    }
}
