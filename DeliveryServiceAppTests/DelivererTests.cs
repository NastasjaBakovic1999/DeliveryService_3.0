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

        [Fact]
        public void TestServiceDelivererFindById()
        {
            var service = new ServiceDeliverer(unitOfWork.Object);
            var result = service.FindByID(1);
            var resultDeliverer = Assert.IsType<Deliverer>(result);
            var expected = unitOfWork.Object.Deliverer.FindByID(1);
            Assert.Equal(expected.Id, resultDeliverer.Id);
        }

        [Fact]
        public void TestServiceDelivererFindByIdInvalid()
        {
            var service = new ServiceDeliverer(unitOfWork.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceDelivererGetAll()
        {
            var service = new ServiceDeliverer(unitOfWork.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<Deliverer>>(result);
            Assert.Equal<int>(5, resultList.Count);
        }
    }
}
