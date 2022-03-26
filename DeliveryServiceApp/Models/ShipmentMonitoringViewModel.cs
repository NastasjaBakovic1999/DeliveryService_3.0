using DeliveryServiceApp.DataAnnotations;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryServiceApp.Models
{
    public class ShipmentMonitoringViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [ValidShipmentCode(ErrorMessage = "The shipment code must have 11 alphanumeric characters.")]
        [DisplayName("Shipment Code")]
        public string ShipmentCode { get; set; }
        public List<StatusShipmentViewModel> ShipmentStatuses { get; set; } = new List<StatusShipmentViewModel>();
        public List<SelectListItem> StatusesSelect { get; set; }
        public int StatusId { get; set; }
    }
}
