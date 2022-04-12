using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Person> userManager;
        private readonly IPersonUnitOfWork unitOfWork;

        public UserController(UserManager<Person> userManager, IPersonUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Customer, Deliverer")]
        public async Task<IActionResult> Index()
        {
            UserProfileViewModel model = new UserProfileViewModel();

            int userId = -1;
            int.TryParse(userManager.GetUserId(HttpContext.User), out userId);

            if (userId != -1)
            {
               var user =  await userManager.FindByIdAsync(userId.ToString());
                
                if(user != null)
                {
                    model.Id = user.Id;
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.Username = user.UserName;
                    model.Email = user.Email;
                    model.PhoneNumber = user.PhoneNumber;

                    var role = await userManager.GetRolesAsync(user);
                    if (role.Contains("Customer"))
                    {
                        var customer = unitOfWork.Customer.FindByID(userId);
                        model.Address = customer.Address;
                        model.PostalCode = customer.PostalCode;
                    }
                    else
                    {
                        var deliverer = unitOfWork.Deliverer.FindByID(userId);
                        model.DateOfEmployment = deliverer.DateOfEmployment;
                    }

                    return View("Detail", model);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "Customer, Deliverer")]
        [HttpGet]
        public IActionResult Edit(UserProfileViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async  Task<IActionResult> Edited(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            var user = await userManager.FindByIdAsync(model.Id.ToString());

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.Username;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                await userManager.UpdateAsync(user);

                var role = await userManager.GetRolesAsync(user);
                if (role.Contains("Customer"))
                {
                    Customer c = new Customer
                    {
                        Address = model.Address,
                        PostalCode = model.PostalCode
                    };

                    unitOfWork.Customer.Edit(c);
                }
                return View("Detail", model);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
