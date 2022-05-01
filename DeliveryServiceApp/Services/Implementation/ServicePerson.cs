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
        public Person FindByID(int id, params int[] ids)
        {
            return unitOfWork.Person.FindByID(id, ids);
        }

        public List<Person> GetAll()
        {
            return unitOfWork.Person.GetAll();
        }
    }
}
