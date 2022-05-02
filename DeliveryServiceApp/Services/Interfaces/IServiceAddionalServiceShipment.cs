using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceAddionalServiceShipment : IService<AdditionalServiceShipment>
    {
        public void Add(AdditionalServiceShipment additionalServiceShipment);
    }
}
