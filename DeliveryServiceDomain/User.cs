using System;
using System.Collections.Generic;

namespace DeliveryServiceDomain
{
    public class User : Person
    {
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string PostalNo { get; set; }
        public Location CityOfResidence { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}
