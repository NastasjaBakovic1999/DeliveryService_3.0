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

        public void Edit(Status status)
        {
            throw new System.NotImplementedException();
        }

        public Status FindByID(int id, params int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public List<Status> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Status GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
