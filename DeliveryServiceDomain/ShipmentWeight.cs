using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class ShipmentWeight
    {
        public int ShipmentWeightId { get; set; }
        public string ShipmentWeightDescpription { get; set; }
        public double ShipmentWeightPrice { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}
