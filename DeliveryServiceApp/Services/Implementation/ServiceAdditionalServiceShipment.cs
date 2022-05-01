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

        public void Delete(AdditionalServiceShipment additionalServiceShipment)
        {
            if (additionalServiceShipment == null) throw new ArgumentException();
            var adds = unitOfWork.AdditionalServiceShipment.FindByID(additionalServiceShipment.AdditionalServiceId, additionalServiceShipment.ShipmentId);
            if(adds == null) throw new Exception();
            unitOfWork.AdditionalServiceShipment.Delete(additionalServiceShipment);
            unitOfWork.Commit();
        }

        public void Edit(AdditionalServiceShipment additionalServiceShipment)
        {
            if (IsValid(additionalServiceShipment) == false) throw new ArgumentOutOfRangeException();
            unitOfWork.AdditionalServiceShipment.Edit(additionalServiceShipment);
            unitOfWork.Commit();
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

        public List<AdditionalServiceShipment> GetByShipmentId(int shipmentId)
        {
            var adds = unitOfWork.AdditionalServiceShipment.GetByShipmentId(shipmentId);
            return adds;
        }

        public List<AdditionalServiceShipment> Search(Expression<Func<AdditionalServiceShipment, bool>> pred)
        {
            if (pred == null) throw new Exception();
            var adds = unitOfWork.AdditionalServiceShipment.Search(pred);
            return adds;
        }
    }
}
