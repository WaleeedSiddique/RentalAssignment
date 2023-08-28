using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;
using static java.util.Locale;

namespace RentalAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IVehicleCategoryInterface _vehicleCategory;

        public CategoryController(IVehicleCategoryInterface vehicleCategory)
        {
            this._vehicleCategory = vehicleCategory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _vehicleCategory.GetAllCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VehicleCategory category)
        {
            if (ModelState.IsValid)
            {
                _vehicleCategory.AddCategory(category);
                return RedirectToAction("Index");
            }
            else {
                ViewBag.message = "Couldn't create category, Kindly check the information you gave again!";
                return View(category);
            }
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _vehicleCategory.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(VehicleCategory category)
        {
            if (ModelState.IsValid)
            {
                _vehicleCategory.UpdateCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var category = _vehicleCategory.GetCategoryById(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult ConfirmedDelete(int id)
        {
            _vehicleCategory.RemoveCategory(id);
            return RedirectToAction("Index");

        }

    }
}
