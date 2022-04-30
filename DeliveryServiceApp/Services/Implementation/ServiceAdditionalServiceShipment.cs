using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceAdditionalServiceShipment : IServiceAddionalServiceShipment
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceAdditionalServiceShipment(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(AdditionalServiceShipment additionalServiceShipment)
        {
            throw new NotImplementedException();
        }

        public void Delete(AdditionalServiceShipment additionalServiceShipment)
        {
            throw new NotImplementedException();
        }

        public void Edit(AdditionalServiceShipment additionalServiceShipment)
        {
            throw new NotImplementedException();
        }

        public AdditionalServiceShipment FindByID(int id, params int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<AdditionalServiceShipment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<AdditionalServiceShipment> GetByShipmentId(int shipmentId)
        {
            throw new NotImplementedException();
        }

        public List<AdditionalServiceShipment> Search(Expression<Func<AdditionalServiceShipment, bool>> pred)
        {
            throw new NotImplementedException();
        }
    }
}
