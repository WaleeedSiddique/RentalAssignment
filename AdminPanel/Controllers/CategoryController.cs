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
            if (category != null)
            {
                var model = new EditCategoryViewModel()
                {
                    CategoryName = category.CategoryName
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditCategory(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _vehicleCategory.GetCategoryById(model.id);
                if(category != null)
                {
                    category.CategoryName = model.CategoryName;
                _vehicleCategory.UpdateCategory(category);
                return RedirectToAction("Index");
                }
                ViewBag.Message = "No Category change";
                return View();
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var category = _vehicleCategory.GetCategoryById(id);
            if(category == null)
            {
                return NotFound();
            }
            _vehicleCategory.RemoveCategory(id);
            return RedirectToAction("Index");
        }

    }
}
