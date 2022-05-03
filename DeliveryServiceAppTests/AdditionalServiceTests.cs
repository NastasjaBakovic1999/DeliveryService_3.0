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
    public class AdditionalServiceTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();

        [Fact]
        public void TestServiceAdditionalServiceFindById()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object);
            var result = service.FindByID(1);
            var resultAdditionalService = Assert.IsType<AdditionalService>(result);
            var expected = unitOfWork.Object.AdditionalService.FindByID(1);
            Assert.Equal(expected.AdditionalServiceId, resultAdditionalService.AdditionalServiceId);
        }

        [Fact]
        public void TestServiceAdditionalServiceFindByIdInvalid()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceAdditionalServiceGetAll()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<AdditionalService>>(result);
            var expected = unitOfWork.Object.AdditionalService.GetAll();
            Assert.Equal<int>(expected.Count, resultList.Count);
        }

    }
}
