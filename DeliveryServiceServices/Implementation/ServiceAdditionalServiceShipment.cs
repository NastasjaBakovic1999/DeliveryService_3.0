using AutoMapper;
using DataTransferObjects;
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
        private readonly IMapper mapper;

        public ServiceAdditionalServiceShipment(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(AdditionalServiceShipmentDto additionalServiceShipment)
        {
            if (!IsValid(additionalServiceShipment)|| AlreadyExistInDB(additionalServiceShipment))
            {
                throw new ArgumentOutOfRangeException("Nevalidan unos!");
            }

            unitOfWork.AdditionalServiceShipment.Add(mapper.Map<AdditionalServiceShipment>(additionalServiceShipment));
            unitOfWork.Commit();
        }

        private bool IsValid(AdditionalServiceShipmentDto additionalServiceShipment)
        {
            bool valid = true;

            if (additionalServiceShipment == null) return false;
            if(additionalServiceShipment.AdditionalServiceId == 0 || additionalServiceShipment.ShipmentId == 0)
            {
                return false;
            }
            if (additionalServiceShipment.AdditionalServiceId < 0 || additionalServiceShipment.ShipmentId < 0)
            {
                return false;
            }

            return valid;
        }

        private bool AlreadyExistInDB(AdditionalServiceShipmentDto additionalServiceShipment)
        {
            bool exist = false;

            if(unitOfWork.AdditionalServiceShipment.GetAll().Any(a => a.AdditionalServiceId == additionalServiceShipment.AdditionalServiceId && 
                                                                    a.ShipmentId == additionalServiceShipment.ShipmentId))
            {
                return true;
            }

            return exist;
        }

        public AdditionalServiceShipmentDto FindByID(int id, params int[] ids)
        {
            var additionalServiceShipment = unitOfWork.AdditionalServiceShipment.FindOneByExpression(adds=> adds.AdditionalServiceId == id && adds.ShipmentId == ids[0]);
            return mapper.Map<AdditionalServiceShipmentDto>(additionalServiceShipment);
        }

        public List<AdditionalServiceShipmentDto> GetAll()
        {
            var additionalServiceShipments = unitOfWork.AdditionalServiceShipment.GetAll();
            return mapper.Map<List<AdditionalServiceShipmentDto>>(additionalServiceShipments);
        }

    }
}
