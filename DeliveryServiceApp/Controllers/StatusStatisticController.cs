using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceDomain;
using DeliveryServiceServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DeliveryServiceApp.Controllers
{
    public class StatusStatisticController : Controller
    {
        private readonly IServiceShipmentStatusStatistic serviceShipmentStatusStatistic;

        public StatusStatisticController(IServiceShipmentStatusStatistic serviceShipmentStatusStatistic)
        {
            this.serviceShipmentStatusStatistic = serviceShipmentStatusStatistic;
        }

        [Authorize(Roles = "Deliverer")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Statistic()
        {
            var statisticData = serviceShipmentStatusStatistic.GetAll();
            return Json(new { JSONList = statisticData } );
        }
    }
}
