using DeliveryServiceDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Filters
{
    public class RedirectDelivererFromHome : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("userrole") != null)
            {
                if (context.HttpContext.Session.GetString("userrole").Contains("Deliverer"))
                {
                    context.HttpContext.Response.Redirect("/Shipment/AllShipments");
                    return;
                }
            }
        }
    }
}
