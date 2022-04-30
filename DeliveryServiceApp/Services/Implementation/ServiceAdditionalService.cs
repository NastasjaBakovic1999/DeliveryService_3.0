using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceAdditionalService : IServiceAdditonalService
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceAdditionalService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public AdditionalService FindByID(int id, params int[] ids)
        {
            AdditionalService additionalService = unitOfWork.AdditionalService.FindByID(id, ids);
            return additionalService;
        }

        public List<AdditionalService> GetAll()
        {
            return unitOfWork.AdditionalService.GetAll();
        }
    }
}
