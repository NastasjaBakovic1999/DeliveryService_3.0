using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!IsValid(statusShipment) || AlreadyExistInDB(statusShipment))
            {
                throw new ArgumentOutOfRangeException("Nevalidan unos!");
            }

            unitOfWork.StatusShipment.Add(statusShipment);
            unitOfWork.Commit();
        }

        private bool IsValid(StatusShipment statusShipment)
        {
            bool valid = true;

            if (statusShipment == null) return false;
            if (statusShipment.StatusId == 0 || statusShipment.ShipmentId == 0)
            {
                return false;
            }
            if (statusShipment.StatusTime > DateTime.Now) return false;

            return valid;
        }

        private bool AlreadyExistInDB(StatusShipment statusShipment)
        {
            bool exist = false;

            if (unitOfWork.StatusShipment.GetAll().Any(a => a.StatusId == statusShipment.StatusId &&
                                                       a.ShipmentId == statusShipment.ShipmentId))
            {
                return true;
            }

            return exist;
        }

        public StatusShipment FindByID(int id, params int[] ids)
        {
            return unitOfWork.StatusShipment.FindByID(id, ids);
        }

        public List<StatusShipment> GetAll()
        {
            return unitOfWork.StatusShipment.GetAll();
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            return unitOfWork.StatusShipment.GetAllByShipmentId(shipmentId);
        }
    }
}
