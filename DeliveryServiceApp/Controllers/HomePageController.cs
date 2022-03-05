using DeliveryServiceData.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApp.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomePageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
