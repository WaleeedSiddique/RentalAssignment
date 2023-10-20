using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Interfaces;

namespace RentalAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AdminController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PendingUsers()
        {
            var pendingusers = _userRepository.GetPendingApprovals();
            return View(pendingusers);
        }
        public IActionResult ApprovedUsers()
        {
            var Approvedusers = _userRepository.GetApprovedUsers();
            if(Approvedusers == null)
            {
                ViewBag.message = "No users approved yet!";
            }
            return View(Approvedusers);
        }
        public IActionResult AppproveUser(string Id)
        {
            var user = _userRepository.GetUserbyId(Id);
            if(user != null)
            {
                user.IsApproved = true;
                _userRepository.UpdateUser(user);
            }
            return RedirectToAction("PendingUsers");
        }
        [HttpGet]
        public IActionResult RejectUser(string Id)
        {
            var user = _userRepository.GetUserbyId(Id);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
            return RedirectToAction("PendingUsers");
            }
            ViewBag.Errormessage = "Something went wrong";
            return RedirectToAction("PendingUsers");
        }
    }
}
