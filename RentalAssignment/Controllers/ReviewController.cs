using Microsoft.AspNetCore.Mvc;
using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;

namespace RentalAssignment.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewInterface _reviewInterface;
        private readonly AddDbContext _context;

        public ReviewController(IReviewInterface reviewInterface, AddDbContext context)
        {
            this._reviewInterface = reviewInterface;
            this._context = context;
        }
        [HttpGet]
        public IActionResult Create(int rentalID)
        {
            var result = _context.rentals.FirstOrDefault(x => x.RentalID == rentalID);
            if(result == null)
            {
                return NotFound();
            }                  
                var model = new ReviewViewModel { RentalId = rentalID };
                return View(model);
            
        }
        [HttpPost]
        public IActionResult Create(ReviewViewModel review)
        {
            if (ModelState.IsValid)
            {
                var model = new Review
                {
                    Rating = review.Rating,
                    Comment = review.Comment,
                    RentalId = review.RentalId
                };
                _reviewInterface.AddReview(model);
                return RedirectToAction("Index", "Home");
            }
            return View(review);
        }
    }
}
