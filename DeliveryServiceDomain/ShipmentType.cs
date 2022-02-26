using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class ShipmentType
    {
        public int ShipmentTypeId { get; set; }
        public string ShipmentTypeName { get; set; }
        public double ShipmentTypePrice { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}
