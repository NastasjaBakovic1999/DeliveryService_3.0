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
    public class PersonTests
    {
        Mock<IPersonUnitOfWork> unitOfWork = Mocks.GetMockPersonUnitOfWork();

        [Fact]
        public void TestServicePersonFindById()
        {
            var service = new ServicePerson(unitOfWork.Object);
            var result = service.FindByID(1);
            var resultPerson = Assert.IsType<Person>(result);
            var expected = unitOfWork.Object.Person.FindByID(1);
            Assert.Equal(expected.Id, resultPerson.Id);
        }

        [Fact]
        public void TestServicePersonFindByIdInvalid()
        {
            var service = new ServicePerson(unitOfWork.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServicePersonGetAll()
        {
            var service = new ServicePerson(unitOfWork.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<Person>>(result);
            Assert.Equal<int>(5, resultList.Count);
        }
    }
}
