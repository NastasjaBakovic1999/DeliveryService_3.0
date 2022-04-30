using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceAddionalServiceShipment : IService<AdditionalServiceShipment>
    {
        public void Add(AdditionalServiceShipment additionalServiceShipment);
        public void Delete(AdditionalServiceShipment additionalServiceShipment);
        public void Edit(AdditionalServiceShipment additionalServiceShipment);
        public List<AdditionalServiceShipment> GetByShipmentId(int shipmentId);
        public List<AdditionalServiceShipment> Search(Expression<Func<AdditionalServiceShipment, bool>> pred);
    }
}
