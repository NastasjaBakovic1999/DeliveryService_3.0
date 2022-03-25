using DeliveryServiceApp.DataAnnotations;
using DeliveryServiceDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryServiceApp.Models
{
    public class ShipmentMonitoringViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [ValidShipmentCode(ErrorMessage = "The shipment code must have 11 digits.")]
        public string ShipmentCode { get; set; }
        public List<StatusShipmentViewModel> ShipmentStatuses { get; set; }
    }
}
