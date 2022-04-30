using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceDeliverer : IServiceDeliverer
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceDeliverer(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Deliverer deliverer)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Deliverer deliverer)
        {
            throw new System.NotImplementedException();
        }

        public Deliverer FindByID(int id, params int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public List<Deliverer> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
