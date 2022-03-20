using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceData.UnitOfWork.Implementation;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryServiceApp.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ShipmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Create()
        {
            List<AdditionalService> additionalServicesList = unitOfWork.AdditionalService.GetAll();
            List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName+" "+s.AdditionalServicePrice, Value = s.AdditionalServiceId.ToString() }).ToList();

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
                return View(model);
            }

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
    }
}
