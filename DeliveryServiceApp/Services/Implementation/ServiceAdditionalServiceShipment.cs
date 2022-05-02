using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!IsValid(additionalServiceShipment)|| AlreadyExistInDB(additionalServiceShipment))
            {
                throw new ArgumentOutOfRangeException("Nevalidan unos!");
            }

            unitOfWork.AdditionalServiceShipment.Add(additionalServiceShipment);
            unitOfWork.Commit();
        }

        private bool IsValid(AdditionalServiceShipment additionalServiceShipment)
        {
            bool valid = true;

            if (additionalServiceShipment == null) return false;
            if(additionalServiceShipment.AdditionalServiceId == 0 || additionalServiceShipment.ShipmentId == 0)
            {
                return false;
            }

            return valid;
        }

        private bool AlreadyExistInDB(AdditionalServiceShipment additionalServiceShipment)
        {
            bool exist = false;

            if(unitOfWork.AdditionalServiceShipment.GetAll().Any(a => a.AdditionalServiceId == additionalServiceShipment.AdditionalServiceId && 
                                                                    a.ShipmentId == additionalServiceShipment.ShipmentId))
            {
                return true;
            }

            return exist;
        }

        public AdditionalServiceShipment FindByID(int id, params int[] ids)
        {
            var additionalServiceShipment = unitOfWork.AdditionalServiceShipment.FindByID(id, ids);
            return additionalServiceShipment;
        }

        public List<AdditionalServiceShipment> GetAll()
        {
            return unitOfWork.AdditionalServiceShipment.GetAll();
        }

    }
}
