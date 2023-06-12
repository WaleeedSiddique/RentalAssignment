using java.lang;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalAssignment.Models;
using RentalAssignment.ViewModels;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;

namespace RentalAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                { 
                    
                    UserName = model.Name,
                    Email = model.Email 
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }                
            }
            return View(model);
        }
       
        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email{email} is already in use");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model,string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result =await _signInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
              
                
            }
            ModelState.AddModelError(string.Empty, "Invalid User Input ");
            return View(model);
        }
        [HttpGet]
        public IActionResult Dashboard(RegistrationViewModel model)
        {                               
            return View(model);
        }
       
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var user = GetCurrentUserAsync();
            var userId = user?.Id;

            if (user == null)
            {
                return View("Error");
            }

            var model = new EditUserViewModel
            {
                Id = userId.ToString(),
                UserName = user.Result.UserName,
                Email = user.Result.Email,               
            };
            return View(model);            
        }
        [HttpPost]
        public async Task<IActionResult>  Update(EditUserViewModel model)
        {
            var user = GetCurrentUserAsync();
            var userId = user?.Id;
            if (user == null)
            {
                return View("Error");
            };
            
            user.Result.UserName = model.UserName;
            user.Result.Email = model.Email;
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string name)
        {
            var user = GetCurrentUserAsync();
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id {user} does not exist";
                return View("Not Found");
            };
            //await _userManager.DeleteAsync(user);
            return RedirectToAction("Register");

        }
    }
}
