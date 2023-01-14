using AutoMapper;
using DataTransferObjects;
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
        private readonly IMapper mapper;

        public ServiceStatusShipment(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(StatusShipmentDto statusShipment)
        {
            if (!IsValid(statusShipment) || AlreadyExistInDB(statusShipment))
            {
                throw new ArgumentOutOfRangeException("Nevalidan unos!");
            }

            unitOfWork.StatusShipment.Add(mapper.Map<StatusShipment>(statusShipment));
            unitOfWork.Commit();
        }

        private bool IsValid(StatusShipmentDto statusShipment)
        {
            bool valid = true;

            if (statusShipment == null) return false;
            if (statusShipment.StatusId == 0 || statusShipment.ShipmentId == 0)
            {
                return false;
            }
            if (statusShipment.StatusId < 0 || statusShipment.ShipmentId < 0)
            {
                return false;
            }
            if (statusShipment.StatusTime > DateTime.Now) return false;

            return valid;
        }

        private bool AlreadyExistInDB(StatusShipmentDto statusShipment)
        {
            bool exist = false;

            if (unitOfWork.StatusShipment.GetAll().Any(a => a.StatusId == statusShipment.StatusId &&
                                                       a.ShipmentId == statusShipment.ShipmentId))
            {
                return true;
            }

            return exist;
        }

        public StatusShipmentDto FindByID(int id, params int[] ids)
        {
            var statusShipment = unitOfWork.StatusShipment.FindOneByExpression(ssh => ssh.StatusId == id && ssh.ShipmentId == ids[0]);
            return mapper.Map<StatusShipmentDto>(statusShipment);
        }

        public List<StatusShipmentDto> GetAll()
        {
            var statusShipments = unitOfWork.StatusShipment.GetAll();
            return mapper.Map<List<StatusShipmentDto>>(statusShipments);
        }

        public List<StatusShipmentDto> GetAllByShipmentId(int shipmentId)
        {
            var statusShipments = unitOfWork.StatusShipment.GetAllByShipmentId(shipmentId);
            return mapper.Map<List<StatusShipmentDto>>(statusShipments);
        }
    }
}
