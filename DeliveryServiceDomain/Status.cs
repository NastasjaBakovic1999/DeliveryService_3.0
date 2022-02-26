using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public List<StatusShipment> Shipments { get; set; }
    }
}
