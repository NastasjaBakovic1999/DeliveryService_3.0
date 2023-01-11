using DataTransferObjects;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceStatusShipment : IService<StatusShipmentDto>
    {
        public void Add(StatusShipmentDto statusShipment);
        public List<StatusShipmentDto> GetAllByShipmentId(int shipmentId);
    }
}
