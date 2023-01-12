using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services.Implementation;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceAppTests
{
    public class CustomerTests
    {
        Mock<IPersonUnitOfWork> unitOfWork = Mocks.GetMockPersonUnitOfWork();
        IMapper mapper = Mocks.GetMockAutoMapper();

        [Fact]
        public void TestServiceCustomerFindById()
        {
            var service = new ServiceCustomer(unitOfWork.Object, mapper);
            var result = service.FindByID(1);
            var resultCustomer = Assert.IsType<CustomerDto>(result);
            var expected = mapper.Map<CustomerDto>(unitOfWork.Object.Customer.FindByID(1));
            Assert.Equal(expected.Id, resultCustomer.Id);
        }

        [Fact]
        public void TestServiceCustomerFindByIdInvalid()
        {
            var service = new ServiceCustomer(unitOfWork.Object, mapper);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceCustomerGetAll()
        {
            var service = new ServiceCustomer(unitOfWork.Object, mapper);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<CustomerDto>>(result);
            var expected = mapper.Map<List<CustomerDto>>(unitOfWork.Object.Customer.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }

        [Fact]
        public void TestServiceCustomerEdit()
        {
            var service = new ServiceCustomer(unitOfWork.Object, mapper);
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Perica",
                LastName = "Peric",
                UserName = "pera",
                Email = "perica@gmail.com",
                Address = "Adresa 1",
                PostalCode = "11000",
                PhoneNumber = "0652233445"
            };
            service.Edit(mapper.Map<CustomerDto>(customer));
            var customerUpdated = unitOfWork.Object.Customer.FindByID(1);

            Assert.Equal(customer.FirstName, customerUpdated.FirstName);
            Assert.Equal(customer.LastName, customerUpdated.LastName);
            Assert.Equal(customer.UserName, customerUpdated.UserName);
            Assert.Equal(customer.Email, customerUpdated.Email);
            Assert.Equal(customer.Address, customerUpdated.Address);
            Assert.Equal(customer.PostalCode, customerUpdated.PostalCode);
            Assert.Equal(customer.PhoneNumber, customerUpdated.PhoneNumber);

            unitOfWork.Verify(x => x.Customer.Edit(It.IsAny<Customer>()), Times.Once);
            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Fact]
        public void TestServiceCustomerEditInvalid()
        {
            var service = new ServiceCustomer(unitOfWork.Object, mapper);
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Perica",
                LastName = "Peric",
                UserName = "pera",
                Email = "perica@gmail.com",
                PostalCode = "11000",
                PhoneNumber = "0652233445"
            };
            
            Assert.Throws<ArgumentOutOfRangeException>(() => service.Edit(mapper.Map<CustomerDto>(customer)));
            unitOfWork.Verify(x => x.Customer.Edit(It.IsAny<Customer>()), Times.Never);
            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }
    }
}
