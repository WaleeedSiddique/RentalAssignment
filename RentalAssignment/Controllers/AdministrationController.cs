using LibGit2Sharp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;

namespace RentalAssignment.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this._userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListUsers()
        {
            var user = _userManager.Users;
            return View(user);
        }

        [HttpGet]
        public IActionResult UpdateUser(string id)
        {
            var result = _userManager.FindByIdAsync(id);
            if(result == null)
            {
                ViewBag.ErrorMessage = $"User with id {result} does not exist";
                return View("Not Found");
            }
            var model = new EditUserViewModel
            {
                UserName = result.Result.UserName,
                Email = result.Result.Email,               
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if(user == null)
            {
                ViewBag.ErrorMessage = "User Not Found";
                return View("Not Found");
            }
            
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) { 
                return RedirectToAction("ListUsers");
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with id {user} does not exist";
                return View("Not Found");
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction("ListUsers");
        }

    }
}
