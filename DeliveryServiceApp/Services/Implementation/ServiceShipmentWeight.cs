using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceShipmentWeight : IServiceShipmentWeight
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceShipmentWeight(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ShipmentWeight FindByID(int id, params int[] ids)
        {
            return unitOfWork.ShipmentWeight.FindByID(id, ids);
        }

        public List<ShipmentWeight> GetAll()
        {
            return unitOfWork.ShipmentWeight.GetAll();
        }
    }
}
