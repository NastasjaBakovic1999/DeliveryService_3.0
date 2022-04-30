using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceShipment : IServiceShipment
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceShipment(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Shipment shipment)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Shipment shipment)
        {
            throw new System.NotImplementedException();
        }

        public Shipment FindByCode(string code)
        {
            throw new System.NotImplementedException();
        }

        public Shipment FindByID(int id, params int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public List<Shipment> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Shipment> GetAllOfSpecifiedUser(int? userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
