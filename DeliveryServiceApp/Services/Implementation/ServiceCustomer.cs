using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceCustomer : IServiceCustomer
    {

        private readonly IUnitOfWork unitOfWork;

        public ServiceCustomer(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Customer FindByID(int id, params int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
