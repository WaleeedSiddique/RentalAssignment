using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class MockReviewRepository : IReviewInterface
    {
        public Review AddReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
