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
                    NormalizedUserName = model.FirstName,
                    UserName = model.username,
                    Email = model.Email,
                    IsApproved = false
                };               
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Pending","Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            }
         
            return View(model);
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
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
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        
        public async Task<IActionResult> Login()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email) ?? await _userManager.FindByNameAsync(model.Email);

                if (user != null)
                {
                    if (user.IsApproved == false)
                    {
                        ViewBag.ErrorMessage = "Your Account is not approved yet!";
                        return View();
                    }
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            if(returnUrl == "/Account/Pending")
                            {
                                var newreturn = "/Home/SearchPage";
                                return Redirect(newreturn);
                            }
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Password Didn't match ");
                    return View();

                }

                ModelState.AddModelError(string.Empty, "No Account with this Email");
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            var user = _userManager.Users.ToList();
            return View(user);
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
        public async Task<IActionResult> Update(EditUserViewModel model)
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
        public IActionResult Pending()
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
