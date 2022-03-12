using DeliveryServiceData.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApp.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ShipmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("Create");
        }
    }
}
