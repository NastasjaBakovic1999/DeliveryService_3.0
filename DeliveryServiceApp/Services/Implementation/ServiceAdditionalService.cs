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
            throw new System.NotImplementedException();
        }

        public List<AdditionalService> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
