using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Models
{
    public class CreateShipmentViewModel
    {
        public double ShipmentWeight { get; set; }
        public string ShipmentContent { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public Location SendingLocation { get; set; }
        public Location ReceivingLocation { get; set; }
        public string Street { get; set; }
        public string PostalNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public List<AdditionalServiceShipment> AdditionalServices { get; set; }
        public string Note { get; set; }
    }
}
