using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceData.UnitOfWork.Implementation;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DeliveryServiceApp.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<Person> userManager;

        public ShipmentController(IUnitOfWork unitOfWork, UserManager<Person> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            List<AdditionalService> additionalServicesList = unitOfWork.AdditionalService.GetAll();
            List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

            List<ShipmentWeight> shipmentWeightList = unitOfWork.ShipmentWeight.GetAll();
            List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();

            CreateShipmentViewModel model = new CreateShipmentViewModel
            {
                AdditionalServices = selectAdditionalServicesList,
                ShipmentWeights = selectShipmentWeightList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateShipmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                List<AdditionalService> additionalServicesList = unitOfWork.AdditionalService.GetAll();
                List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

                List<ShipmentWeight> shipmentWeightList = unitOfWork.ShipmentWeight.GetAll();
                List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();

                model.AdditionalServices = selectAdditionalServicesList;
                model.ShipmentWeights = selectShipmentWeightList;

                return View(model);
            }

            Shipment shipment = new Shipment
            {
                ShipmentWeightId = model.ShipmentWeightId,
                ShipmentContent = model.ShipmentContent,
                ContactPersonName = model.ContactPersonName,
                ContactPersonPhone = model.ContactPersonPhone,
                Note = model.Note,
                ReceivingAddress = model.ReceivingAddress,
                ReceivingCity = model.ReceivingCity,
                ReceivingPostalCode = model.ReceivingPostalCode,
                SendingAddress = model.SendingAddress,
                SendingCity = model.SendingCity,
                SendingPostalCode = model.SendingPostalCode,
                DelivererId = 3
            };

            Random rand = new Random();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            shipment.ShipmentCode = new string(Enumerable.Repeat(chars, 11)
                                                          .Select(s => s[rand.Next(chars.Length)])
                                                          .ToArray());


            int userId = -1;
            int.TryParse(userManager.GetUserId(HttpContext.User), out userId);

            if (userId != -1)
            {
                shipment.CustomerId = userId;
            }

            double weightPrice = unitOfWork.ShipmentWeight.FindByID(model.ShipmentWeightId).ShipmentWeightPrice;
            double additionalServicesPrice = 0;

            if (model.Services != null && model.Services.Count() > 0)
            {
                List<AdditionalService> additionalServices = unitOfWork.AdditionalService.GetAll();

                foreach (AdditonalServiceViewModel sa in model.Services)
                {
                    additionalServicesPrice += additionalServices.Find(s => s.AdditionalServiceId == sa.AdditionalServiceId).AdditionalServicePrice;
                }
            }

            shipment.Price = weightPrice + additionalServicesPrice;

            unitOfWork.Shipment.Add(shipment);
            unitOfWork.Commit();

            foreach (AdditonalServiceViewModel sa in model.Services)
            {
                AdditionalServiceShipment ass = new AdditionalServiceShipment();
                ass.AdditionalServiceId = sa.AdditionalServiceId;
                ass.ShipmentId = shipment.ShipmentId;
                unitOfWork.AdditionalServiceShipment.Add(ass);
            }

            StatusShipment ss = new StatusShipment
            {
                ShipmentId = shipment.ShipmentId,
                StatusId = unitOfWork.Status.GetByName("Scheduled").StatusId,
                StatusTime = DateTime.Now
            };

            unitOfWork.StatusShipment.Add(ss);
            unitOfWork.Commit();

            return RedirectToAction("CustomerShipments");
        }

        public IActionResult AddService(int additionalServiceId, int number)
        {
            AdditionalService service = unitOfWork.AdditionalService.FindByID(additionalServiceId);

            AdditonalServiceViewModel model = new AdditonalServiceViewModel
            {
                AdditionalServiceId = service.AdditionalServiceId,
                AddtionalServiceName = service.AdditionalServiceName,
                AdditonalServicePrice = service.AdditionalServicePrice,
                Sn = number
            };

            return PartialView(model);
        }

        public IActionResult CustomerShipments()
        {
            int userId = -1;
            int.TryParse(userManager.GetUserId(HttpContext.User), out userId);

            List<Shipment> model = unitOfWork.Shipment.GetAllOfSpecifiedUser(userId);

            return View(model);
        }

        public IActionResult AllShipments()
        {
            List<Shipment> model = unitOfWork.Shipment.GetAll();

            return View(model);
        }

        public IActionResult ShipmentMonitoring()
        {
            ShipmentMonitoringViewModel model = new ShipmentMonitoringViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult ShipmentMonitoring(ShipmentMonitoringViewModel model)
        {
            Shipment shipment = unitOfWork.Shipment.FindByCode(model.ShipmentCode);

            if(shipment == null)
            {
                ModelState.AddModelError(string.Empty, "The shipment code you entered does not exist. Please check your code and try again.");
                return View("ShipmentMonitoring");
            }

            List<StatusShipment> statusShipmentList = unitOfWork.StatusShipment.GetAllByShipmentId(shipment.ShipmentId);

            List<Status> statusesList = unitOfWork.Status.GetAll();

            foreach (StatusShipment ss in statusShipmentList)
            {
                StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                {
                    StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                    StatusTime = ss.StatusTime
                };
                model.ShipmentStatuses.Add(ssvm);
            }

            return View("ShipmentStatuses", model);
        }

        public IActionResult EditStatus(int id)
        {
            Shipment shipment = unitOfWork.Shipment.FindByID(id);

            List<StatusShipment> statusShipmentList = unitOfWork.StatusShipment.GetAllByShipmentId(shipment.ShipmentId);
            List<Status> statusesList = unitOfWork.Status.GetAll();
            List<SelectListItem> statusesSelectList = statusesList.Select(s => new SelectListItem { Text = s.StatusName, Value = s.StatusId.ToString() }).ToList();

            ShipmentMonitoringViewModel model = new ShipmentMonitoringViewModel
            {
                ShipmentCode = shipment.ShipmentCode,
                StatusesSelect = statusesSelectList
            };

            foreach (StatusShipment ss in statusShipmentList)
            {
                StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                {
                    StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                    StatusTime = ss.StatusTime
                };
                model.ShipmentStatuses.Add(ssvm);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult EditStatus(int id, ShipmentMonitoringViewModel model)
        {
            unitOfWork.StatusShipment.Add(new StatusShipment
            {
                ShipmentId = id,
                StatusId = model.StatusId,
                StatusTime = DateTime.Now
            });

            unitOfWork.Commit();

            return RedirectToAction("AllShipments");
        }
    }   
}
