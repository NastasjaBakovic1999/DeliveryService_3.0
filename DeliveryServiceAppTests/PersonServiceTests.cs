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
    public class PersonServiceTests
    {
        Mock<IPersonUnitOfWork> unitOfWork = Mocks.GetMockPersonUnitOfWork();
        IMapper mapper = Mocks.GetMockAutoMapper();

        [Fact]
        public void TestServicePersonFindById()
        {
            var service = new ServicePerson(unitOfWork.Object, mapper);
            var result = service.FindByID(1);
            var resultPerson = Assert.IsType<PersonDto>(result);
            var expected = mapper.Map<PersonDto>(unitOfWork.Object.Person.FindOneByExpression(x => x.Id == 1));
            Assert.Equal(expected.Id, resultPerson.Id);
        }

        [Fact]
        public void TestServicePersonFindByIdInvalid()
        {
            var service = new ServicePerson(unitOfWork.Object, mapper);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServicePersonGetAll()
        {
            var service = new ServicePerson(unitOfWork.Object, mapper);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<PersonDto>>(result);
            var expected = mapper.Map<List<PersonDto>>(unitOfWork.Object.Person.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }
    }
}
