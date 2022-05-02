using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceShipment : IService<Shipment>
    {
        public void Add(Shipment shipment);
        public List<Shipment> GetAllOfSpecifiedUser(int? userId);
        public Shipment FindByCode(string code);
    }
}
