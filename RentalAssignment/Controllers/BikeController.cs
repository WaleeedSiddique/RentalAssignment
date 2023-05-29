using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;
using System.Diagnostics;

namespace RentalAssignment.Controllers
{
    public class BikeController : Controller
    {
        private readonly IBikeInterface _BikeInterface;

        public BikeController(IBikeInterface BikeInterface)
        {

            this._BikeInterface = BikeInterface;
        }

        public IActionResult Index()
        {
            var model = _BikeInterface.GetAllBikes();
            return View(model);
        }
        [Route("Bike/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            var model = _BikeInterface.GetBike(id ?? 1);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                Bike model = _BikeInterface.CreateBike(bike);
                return RedirectToAction("Index", new {model.BikeId});

            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Bike result = _BikeInterface.GetBike(id);
            EditBikeViewModel editBikeViewModel = new EditBikeViewModel
            {
                OwnerName = result.OwnerName,
                ChassisNumber = result.ChassisNumber,
                BikeColour = result.BikeColour,
                BikeModel = result.BikeModel,
                BikeNumberPlate = result.BikeNumberPlate,
                BikeEngine = result.BikeEngine,
                sittingCapacity = result.sittingCapacity,
                OwnerPhone = result.OwnerPhone,

            };
            return View(editBikeViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditBikeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bike result = _BikeInterface.GetBike(model.BikeId);

                Bike newBike = new Bike()
                {
                    OwnerName = model.OwnerName,
                    BikeColour = model.BikeColour,
                    BikeModel = model.BikeModel,
                    BikeNumberPlate = model.BikeNumberPlate,                    
                    ChassisNumber = model.ChassisNumber,
                    BikeEngine = model.BikeEngine,
                    sittingCapacity = model.sittingCapacity,
                    OwnerPhone = model.OwnerPhone,
                };

                _BikeInterface.CreateBike(newBike);
                return RedirectToAction("Details", new { id = newBike.BikeId });
            }
            return View();

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            _BikeInterface.Delete(id);
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

