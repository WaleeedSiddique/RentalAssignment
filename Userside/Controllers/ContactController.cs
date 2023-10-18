using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactInterface _contact;

        public ContactController(IContactInterface contact)
        {
            this._contact = contact;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact newcontact)
        {
            if (ModelState.IsValid)
            {
                Contact model = _contact.AddContact(newcontact);
                return RedirectToAction("Index", new { model.Id });

            }
            return View();
        }
    }
}
