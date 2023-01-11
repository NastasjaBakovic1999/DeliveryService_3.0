using DataTransferObjects;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceShipment : IService<ShipmentDto>
    {
        public void Add(ShipmentDto shipment);
        public List<ShipmentDto> GetAllOfSpecifiedUser(int? userId);
        public ShipmentDto FindByCode(string code);
    }
}
