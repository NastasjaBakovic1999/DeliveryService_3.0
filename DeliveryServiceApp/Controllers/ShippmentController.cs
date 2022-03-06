using DeliveryServiceData.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApp.Controllers
{
    public class ShippmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ShippmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
