using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceStatusShipment : IServiceStatusShipment
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceStatusShipment(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(StatusShipment statusShipment)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(StatusShipment statusShipment)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(StatusShipment statusShipment)
        {
            throw new System.NotImplementedException();
        }

        public StatusShipment FindByID(int id, params int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public List<StatusShipment> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}
