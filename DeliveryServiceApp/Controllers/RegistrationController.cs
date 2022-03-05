using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public RegistrationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.FirstName == null || model.LastName == null || model.Username == null || model.Email == null || model.PhoneNumber == null || model.Password == null)
                {
                    return View("Index");
                }
            }
                User user = unitOfWork.User.Search(u => u.Username == model.Username || u.Email == model.Email);
                if (user == null)
                {
                    unitOfWork.User.Add(user);
                    unitOfWork.Commit();
                    return RedirectToAction("Index", "Login");
                } else 
                {
                    if (user.Email == model.Email)
                    {
                        ModelState.AddModelError(string.Empty, "Email is already taken!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Username is already taken!");
                    }
                    return View(model);
                }
        }
        
    }
}
