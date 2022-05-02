using DeliveryServiceApp.Models;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<Person> userManager;
        private readonly SignInManager<Person> signInManager;

        public AuthenticationController(UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region registration
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterViewModel model)
        {
            Customer customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                PostalCode = model.PostalCode
            };

            if(string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.PasswordConfirm) || !model.Password.Equals(model.PasswordConfirm))
            {
                ModelState.AddModelError("Password", "Password not added");
                return View();
            }

            var result = await userManager.CreateAsync(customer, model.Password);

            if (result.Succeeded)
            {
                var currentUser = await userManager.FindByNameAsync(customer.UserName);

                var roleresult = await userManager.AddToRoleAsync(currentUser, "Customer");

                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                if(result.Errors.Any(e => e.Code.Contains("DuplicateUserName")))
                {
                    ModelState.AddModelError("Username", result.Errors.FirstOrDefault(e => e.Code == "DuplicateUserName")?.Description);
                }
                if (result.Errors.Any(e => e.Code.Contains("Password")))
                {
                    ModelState.AddModelError("Password", result.Errors.FirstOrDefault(e => e.Code.Contains("Password"))?.Description);
                }
                return View();
            }
        }
        #endregion

        #region login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            

            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                var roles = await userManager.GetRolesAsync(user);

                if (roles.Contains("Deliverer"))
                {
                    HttpContext.Session.SetString("userrole", "Deliverer");
                }

                if (roles.Contains("Customer"))
                {
                    HttpContext.Session.SetString("userrole", "Customer");
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Wrong credentials!");
            return View();
        }
        #endregion

        #region logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailValid(string email)
        {
            bool valid = true;

            if (email != null)
            {
                if (!Regex.IsMatch(email.ToString(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    valid = false;
                }
            }

            var user = await userManager.FindByEmailAsync(email);

            if(user == null && valid == true)
            {
                return Json(true);
            }
            else
            {
                if(valid==true && user != null)
                {
                    return Json($"{email} is already registered!");
                } else
                {
                    return Json($"{email} is not in the correct format!");
                }
            }
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsUsernameInUse(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"{username} is already in use!");
            }
        }


    }
}
