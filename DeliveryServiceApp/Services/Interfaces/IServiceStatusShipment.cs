using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceStatusShipment : IService<StatusShipment>
    {
        public void Add(StatusShipment statusShipment);
        public List<StatusShipment> GetAllByShipmentId(int shipmentId);
    }
}
