using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlReviewRepository:IReviewInterface
    {
        private readonly AddDbContext _context;

        public SqlReviewRepository(AddDbContext context)
        {
            this._context = context;
        }
        public Review AddReview(Review review)
        {
            _context.reviews.Add(review);
            _context.SaveChanges();
            return review;
        }
    }
}
