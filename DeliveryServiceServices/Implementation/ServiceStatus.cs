using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceStatus : IServiceStatus
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServiceStatus(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public StatusDto FindByID(int id, params int[] ids)
        {
            var status = unitOfWork.Status.FindByID(id, ids);
            return mapper.Map<StatusDto>(status);
        }

        public List<StatusDto> GetAll()
        {
            var statuses = unitOfWork.Status.GetAll();
            return mapper.Map<List<StatusDto>>(statuses);
        }

        public StatusDto GetByName(string name)
        {
            var status = unitOfWork.Status.GetByName(name);
            return mapper.Map<StatusDto>(status);
        }
    }
}
