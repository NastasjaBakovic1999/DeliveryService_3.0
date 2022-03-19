using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace DeliveryServiceApp.Models
{
    public class CreateShipmentViewModel
    {
        [DisplayName("Shipment Weight")]
        public double ShipmentWeight { get; set; }

        [DisplayName("Shipment Content")]
        public string ShipmentContent { get; set; }

        [DisplayName("Sending City")]
        public string SendingCity { get; set; }

        [DisplayName("Sending Address")]
        public string SendingAddress { get; set; }

        [DisplayName("Sending Postal Code")]
        public string SendingPostalCode { get; set; }

        [DisplayName("Receiving City")]
        public string ReceivingCity { get; set; }

        [DisplayName("Receiving Address")]
        public string ReceivingAddress { get; set; }

        [DisplayName("Receiving Postal Code")]
        public string ReceivingPostalCode { get; set; }

        [DisplayName("Contact Person Name")]
        public string ContactPersonName { get; set; }

        [DisplayName("Contact Person Phone")]
        public string ContactPersonPhone { get; set; }

        public string Note { get; set; }
        public List<SelectListItem> AdditionalServices { get; set; }
    }
}
