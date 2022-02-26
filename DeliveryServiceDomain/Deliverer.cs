using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class Deliverer : Person
    {
        public List<Shipment> Shipments { get; set; }
    }
}
