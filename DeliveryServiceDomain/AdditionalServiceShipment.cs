using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class AdditionalServiceShipment
    {
        public int AdditionalServiceId { get; set; }
        public AdditionalService AdditionalService { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
