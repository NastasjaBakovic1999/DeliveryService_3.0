using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
