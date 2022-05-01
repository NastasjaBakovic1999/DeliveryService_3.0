using DeliveryServiceApp.Models;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Person> userManager;
        private readonly IServiceCustomer serviceCustomer;
        private readonly IServiceDeliverer serviceDeliverer;

        public UserController(UserManager<Person> userManager, IServiceCustomer serviceCustomer, IServiceDeliverer serviceDeliverer)
        {
            this.userManager = userManager;
            this.serviceCustomer = serviceCustomer;
            this.serviceDeliverer = serviceDeliverer;
        }

        [Authorize(Roles = "Customer, Deliverer")]
        public async Task<IActionResult> Index()
        {
            UserProfileViewModel model = new UserProfileViewModel();

            try
            {
                var userId = int.Parse(userManager.GetUserId(HttpContext.User));
                var user = await userManager.FindByIdAsync(userId.ToString());

                if (user != null)
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
                        var customer = serviceCustomer.FindByID(userId);
                        model.Address = customer.Address;
                        model.PostalCode = customer.PostalCode;
                    }
                    else
                    {
                        var deliverer = serviceDeliverer.FindByID(userId);
                        model.DateOfEmployment = deliverer.DateOfEmployment;
                    }

                    return View("Detail", model);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { Message = "Error reading user data!" });
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home", new { Message = ex.Message });
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

            try
            {
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

                        serviceCustomer.Edit(c);
                    }
                    return View("Detail", model);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { Message = "Error reading user data!" });
                }

            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }
    }
}
