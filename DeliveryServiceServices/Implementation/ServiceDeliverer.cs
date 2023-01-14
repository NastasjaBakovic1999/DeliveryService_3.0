using AutoMapper;
using DataTransferObjects;
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
        private readonly IMapper mapper;

        public ServiceDeliverer(IPersonUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public DelivererDto FindByID(int id, params int[] ids)
        {
            var deliverer = unitOfWork.Deliverer.FindOneByExpression(d => d.Id == id);
            return mapper.Map<DelivererDto>(deliverer);
        }

        public List<DelivererDto> GetAll()
        {
            var deliverers = unitOfWork.Deliverer.GetAll();
            return mapper.Map<List<DelivererDto>>(deliverers);
        }
    }
}
