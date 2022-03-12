using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeliveryServiceApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ShipmentList()
        {
            int? userId = HttpContext.Session.GetInt32("PersonId");
            List<Shipment> model = unitOfWork.Shipment.GetAllOfSpecifiedUser(userId); 

            if(model == null)
            {
                return RedirectToAction("Shipment", "Create");
            }
            else
            {
                return View("ShipmentsList", model);
            }
        }
    }
}
