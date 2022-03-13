using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceDomain
{
    public class Customer : Person
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
