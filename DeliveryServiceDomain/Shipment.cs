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
        public double ShipmentWeight { get; set; }
        public string ShipmentContent { get; set; }
        public int ShipmentTypeId { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public int SendingLocationId { get; set; }
        public Location SendingLocation { get; set; }
        public int ReceivingLocationId { get; set; }
        public Location ReceivingLocation { get; set; }
        public string Street { get; set; }
        public string PostalNo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DelivererId { get; set; }
        public Deliverer Deliverer { get; set; }
        public double Price { get; set; }
        public List<AdditionalServiceShipment> AdditionalServices { get; set; }
        public List<StatusShipment> ShipmentStatuses { get; set; }
        public string Note { get; set; }
    }
}
