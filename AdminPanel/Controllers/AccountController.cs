using java.lang;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;
using System.Security.Claims;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;

namespace RentalAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        
        [HttpPost]
        public async Task<IActionResult> AdminLogout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("AdminLogin", "Account");
        }
        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Dashboard()
        //{
        //    var user = _userManager.Users.ToList();
        //    return View(user);
        //}

        [HttpGet]
        public async Task<IActionResult> AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await  _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Dashboard");
                    }
                }
              

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> RemoveUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id {user} does not exist";
                return View("Not Found");
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Pending()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(User);

            //var user = _userManager.FindByIdAsync(id);
            if(user != null) { 
            EditUserViewModel model = new EditUserViewModel
            {
                Id = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                UserName = user.UserName,
                Email = user.Email
            };
            return View(model);
            }
            return NotFound();

            //var user = GetCurrentUserAsync();
            //var name = user.Result.UserName,
            //    var email-
        }
        [HttpPost]
        public async Task<IActionResult> MyAccount(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if(user != null) 
            {
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                      return RedirectToAction("Index", "Home");
                }
                 
            }            
            ViewBag.message = "Something went wrong";
            return View();
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.message = "Something went wrong";
            return View();

        }








    }
}
