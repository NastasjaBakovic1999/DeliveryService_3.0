using DeliveryServiceApp.Models;
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
        private readonly UnitOfWork unitOfWork;

        public ShipmentController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<AdditionalService> additionalServicesList = unitOfWork.AdditionalService.GetAll();
            List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName+" "+s.AdditionalServicePrice, Value = s.AdditionalServiceId.ToString() }).ToList();

            CreateShipmentViewModel model = new CreateShipmentViewModel
            {
                AdditionalServices = selectAdditionalServicesList
            };

            return View(model);
        }

        //[HttpPost]
        //public IActionResult Create(CreateShipmentViewModel model)
        //{

        //}
    }
}
