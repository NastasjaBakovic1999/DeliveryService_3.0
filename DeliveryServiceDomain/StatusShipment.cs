using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class StatusShipment
    {
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public DateTime StatusTime { get; set; }
    }
}
