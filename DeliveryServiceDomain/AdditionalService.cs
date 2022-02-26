using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class AdditionalService
    {
        public int AdditionalServiceId { get; set; }
        public string AdditionalServiceName { get; set; }
        public double AdditionalServicePrice { get; set; }
        public List<AdditionalServiceShipment> Shipments { get; set; }
    }
}
