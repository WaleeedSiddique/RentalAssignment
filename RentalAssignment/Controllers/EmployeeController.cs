using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;
using System.Diagnostics;

namespace RentalAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeInterface _EmployeeInterface;


        public EmployeeController(IEmployeeInterface EmployeeInterface)
        {

            this._EmployeeInterface = EmployeeInterface;

        }

        public IActionResult Index()
        {
            var model = _EmployeeInterface.GetAllEmployee();
            return View(model);
        }
        [Route("Employee/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            var model = _EmployeeInterface.GetEmployee(id ?? 1);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee model = _EmployeeInterface.CreateEmployee(employee);
                return RedirectToAction("Index", new { model.EmployeeId });

            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee result = _EmployeeInterface.GetEmployee(id);
            EditEmployeeViewModel EditEmployeeViewModel = new EditEmployeeViewModel
            {
                EmployeeName = result.EmployeeName,
                EmployeeFatherName = result.EmployeeFatherName,
                EmployeeCNIC = result.EmployeeCNIC,
                EmployeeOccupation = result.EmployeeOccupation,
                EmployeeAge = result.EmployeeAge,
                EmployeeExperience = result.EmployeeExperience,

            };
            return View(EditEmployeeViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee result = _EmployeeInterface.GetEmployee(model.EmployeeId);

                Employee newEmployee = new Employee()
                {
                EmployeeName = model.EmployeeName,
                EmployeeFatherName = model.EmployeeFatherName,
                EmployeeCNIC = model.EmployeeCNIC,
                EmployeeOccupation = model.EmployeeOccupation,
                EmployeeAge = model.EmployeeAge,
                EmployeeExperience = model.EmployeeExperience,
                
            };

                _EmployeeInterface.CreateEmployee(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.EmployeeId });
            }
            return View();

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            _EmployeeInterface.Delete(id);
            return RedirectToAction("Index");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
