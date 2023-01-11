using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceShipmentWeight : IServiceShipmentWeight
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServiceShipmentWeight(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ShipmentWeightDto FindByID(int id, params int[] ids)
        {
            var shipmentWeight = unitOfWork.ShipmentWeight.FindByID(id, ids);
            return mapper.Map<ShipmentWeightDto>(shipmentWeight);
        }

        public List<ShipmentWeightDto> GetAll()
        {
            var shipmentWeights = unitOfWork.ShipmentWeight.GetAll();
            return mapper.Map<List<ShipmentWeightDto>>(shipmentWeights);
        }
    }
}
