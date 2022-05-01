using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceDeliverer : IServiceDeliverer
    {
        private readonly IPersonUnitOfWork unitOfWork;

        public ServiceDeliverer(IPersonUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Deliverer FindByID(int id, params int[] ids)
        {
            return unitOfWork.Deliverer.FindByID(id, ids);
        }

        public List<Deliverer> GetAll()
        {
            return unitOfWork.Deliverer.GetAll();
        }
    }
}
