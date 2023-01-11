using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System.Collections.Generic;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServicePerson : IServicePerson
    {
        private readonly IPersonUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServicePerson(IPersonUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public PersonDto FindByID(int id, params int[] ids)
        {
            var person = unitOfWork.Person.FindByID(id, ids);
            return mapper.Map<PersonDto>(person);
        }

        public List<PersonDto> GetAll()
        {
            var persons = unitOfWork.Person.GetAll();
            return mapper.Map<List<PersonDto>>(persons);
        }
    }
}
