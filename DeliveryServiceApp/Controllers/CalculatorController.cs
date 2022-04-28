using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryServiceApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CalculatorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Customer")]
        public IActionResult CalculateShipment()
        {
            List<AdditionalService> additionalServicesList = unitOfWork.AdditionalService.GetAll();
            List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

            List<ShipmentWeight> shipmentWeightList = unitOfWork.ShipmentWeight.GetAll();
            List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();

            CalculatorViewModel model = new CalculatorViewModel
            {
                AdditionalServices = selectAdditionalServicesList,
                ShipmentWeights = selectShipmentWeightList
            };

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult CalculateShipment(CalculatorViewModel model)
        {
            List<AdditionalService> additionalServicesList = unitOfWork.AdditionalService.GetAll();
            List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

            List<ShipmentWeight> shipmentWeightList = unitOfWork.ShipmentWeight.GetAll();
            List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();
           
            if (!ModelState.IsValid)
            {
                model.AdditionalServices = selectAdditionalServicesList;
                model.ShipmentWeights = selectShipmentWeightList;
                
                return View("Create", model);
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

            model.Price = weightPrice + additionalServicesPrice;

            model.AdditionalServices = selectAdditionalServicesList;
            model.ShipmentWeights = selectShipmentWeightList;

            return View("Create", model);
        }
    }
}
