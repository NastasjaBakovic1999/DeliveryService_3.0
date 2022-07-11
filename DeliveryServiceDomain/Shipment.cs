using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public int ShipmentWeightId { get; set; }
        public ShipmentWeight ShipmentWeight { get; set; }
        public string ShipmentContent { get; set; }
        public Address Sending { get; set; }
        public Address Receiving { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int DelivererId { get; set; }
        public Deliverer Deliverer { get; set; }
        public double Price { get; set; }
        public List<AdditionalServiceShipment> AdditionalServices { get; set; }
        public List<StatusShipment> ShipmentStatuses { get; set; }
        public string Note { get; set; }
    }
}
