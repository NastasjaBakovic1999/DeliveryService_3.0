using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public List<Shipment> SendingShipments { get; set; }
        public List<Shipment> ReceivingShipments { get; set; }
    }
}
