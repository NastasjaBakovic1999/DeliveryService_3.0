using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServicePerson : IServicePerson
    {
        private readonly IPersonUnitOfWork unitOfWork;

        public ServicePerson(IPersonUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Person person)
        {
            throw new System.NotImplementedException();
        }

        public Person FindByID(int id, params int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
