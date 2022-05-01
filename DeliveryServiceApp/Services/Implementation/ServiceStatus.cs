using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceStatus : IServiceStatus
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceStatus(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Status FindByID(int id, params int[] ids)
        {
            return unitOfWork.Status.FindByID(id, ids);
        }

        public List<Status> GetAll()
        {
            return unitOfWork.Status.GetAll();
        }

        public Status GetByName(string name)
        {
            return unitOfWork.Status.GetByName(name);
        }
    }
}
