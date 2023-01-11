using AutoMapper;
using DataTransferObjects;
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
        private readonly IMapper mapper;

        public UserController(UserManager<Person> userManager, IServiceCustomer serviceCustomer, IServiceDeliverer serviceDeliverer, IMapper mapper)
        {
            this.userManager = userManager;
            this.serviceCustomer = serviceCustomer;
            this.serviceDeliverer = serviceDeliverer;
            this.mapper = mapper;
        }

        [Authorize(Roles = "User, Deliverer")]
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
                    if (role.Contains("User"))
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

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Edit(UserProfileViewModel model)
        {
             return View(model);
        }

        [HttpPost]
        public async  Task<IActionResult> Edited(UserProfileViewModel model)
        {
            try
            {
                var user = await userManager.FindByIdAsync(model.Id.ToString());

                if (!ModelState.IsValid)
                {
                    return View("Edit", model);
                }

                if (user != null && !string.IsNullOrEmpty(model.FirstName) && !string.IsNullOrEmpty(model.LastName)
                    && !string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.PhoneNumber))
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;

                    await userManager.UpdateAsync(user);

                    Customer c = new Customer
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Address = model.Address,
                        PostalCode = model.PostalCode
                    };

                    serviceCustomer.Edit(mapper.Map<CustomerDto>(c));

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
