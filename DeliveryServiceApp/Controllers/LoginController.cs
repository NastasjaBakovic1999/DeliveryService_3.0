using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login (LoginViewModel model)
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
    }
}
