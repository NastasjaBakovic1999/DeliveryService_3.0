using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceDomain
{
    public class User : Person
    {
        public string PhoneNumber { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}
