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
    public class DelivererTests
    {
        Mock<IPersonUnitOfWork> unitOfWork = Mocks.GetMockPersonUnitOfWork();
        IMapper mapper = Mocks.GetMockAutoMapper();

        [Fact]
        public void TestServiceDelivererFindById()
        {
            var service = new ServiceDeliverer(unitOfWork.Object, mapper);
            var result = service.FindByID(1);
            var resultDeliverer = Assert.IsType<DelivererDto>(result);
            var expected = mapper.Map<DelivererDto>(unitOfWork.Object.Deliverer.FindOneByExpression(x => x.Id == 1));
            Assert.Equal(expected.Id, resultDeliverer.Id);
        }

        [Fact]
        public void TestServiceDelivererFindByIdInvalid()
        {
            var service = new ServiceDeliverer(unitOfWork.Object, mapper);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceDelivererGetAll()
        {
            var service = new ServiceDeliverer(unitOfWork.Object, mapper);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<DelivererDto>>(result);
            var expected = mapper.Map<List<DelivererDto>>(unitOfWork.Object.Deliverer.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }
    }
}
