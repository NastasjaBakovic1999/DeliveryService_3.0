using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceAdditionalService : IServiceAdditonalService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServiceAdditionalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public AdditionalServiceDto FindByID(int id, params int[] ids)
        {
            var additionalService = unitOfWork.AdditionalService.FindByID(id, ids);
            return mapper.Map<AdditionalServiceDto>(additionalService);
        }

        public List<AdditionalServiceDto> GetAll()
        {
            var additonalServices = unitOfWork.AdditionalService.GetAll();
            return mapper.Map<List<AdditionalServiceDto>>(additonalServices);
        }
    }
}
