using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DeliveryServiceApp.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomePageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                Person person = unitOfWork.Person.GetPersonByUsernameAndPassword(new Person
                {
                    Username = model.Username,
                    Password = model.Password
                });
                HttpContext.Session.SetInt32("PersonId", person.PersonId);
                return RedirectToAction("Index", "HomePage");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Wrong credentials!");
                return View("Index");
            }
        }

        public IActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.FirstName == null || model.LastName == null || model.Username == null || model.Email == null || model.PhoneNumber == null || model.Password == null)
                {
                    return View("Registration");
                }
            }
            User u = unitOfWork.User.Search(u => u.Username == model.Username || u.Email == model.Email);
            if (u == null)
            {
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password
                };
                unitOfWork.User.Add(user);
                unitOfWork.Commit();
                ViewBag.Message = string.Format("You have successfully registered! Now log in with your username and password.");
                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                if (u.Email == model.Email)
                {
                    ModelState.AddModelError(string.Empty, "Email is already taken!");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username is already taken!");
                }
                return View("Registration", model);
            }
        }
    }
}
