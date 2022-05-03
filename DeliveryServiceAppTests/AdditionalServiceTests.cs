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
        public void TestServiceAdditionalServiceFindBy()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object);
            var result = service.FindByID(1);
            var resultAdditionalService = Assert.IsType<AdditionalService>(result);
            var expected = unitOfWork.Object.AdditionalService.FindByID(1);
            Assert.Equal(expected.AdditionalServiceId, resultAdditionalService.AdditionalServiceId);
        }

        [Fact]
        public void TestServiceAdditionalServiceFindByInvalid()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }
    }
}
