using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceCustomer : IServiceCustomer
    {

        private readonly IPersonUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServiceCustomer(IPersonUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Edit(CustomerDto customer)
        {
            if (!IsValid(customer))
            {
                throw new ArgumentOutOfRangeException("Invalid entry!");
            }

            unitOfWork.Customer.Edit(mapper.Map<Customer>(customer));
            unitOfWork.Commit();
        }

        private bool IsValid(CustomerDto customer)
        {
            bool valid = true;

            if (customer == null) return false;
            if (string.IsNullOrEmpty(customer.Address) || string.IsNullOrEmpty(customer.PostalCode))
            {
                return false;
            }

            return valid;
        }


        public CustomerDto FindByID(int id, params int[] ids)
        {
            var customer = unitOfWork.Customer.FindOneByExpression(c => c.Id == id);
            return mapper.Map<CustomerDto>(customer);
        }

        public List<CustomerDto> GetAll()
        {
            var customers = unitOfWork.Customer.GetAll();
            return mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
