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
    public class AdditionalServiceShipmentTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();

        [Fact]
        public void TestServiceAdditionalServiceShipmentFindById()
        {
            var service = new ServiceAdditionalServiceShipment(unitOfWork.Object);
            var result = service.FindByID(1, new int[] {1});
            var resultAdditionalServiceShipment = Assert.IsType<AdditionalServiceShipment>(result);
            var expected = unitOfWork.Object.AdditionalServiceShipment.FindByID(1, new int[] { 1 });
            Assert.Equal(expected.AdditionalServiceId, resultAdditionalServiceShipment.AdditionalServiceId);
            Assert.Equal(expected.ShipmentId, resultAdditionalServiceShipment.ShipmentId);
        }

        [Fact]
        public void TestServiceAdditionalServiceShipmentFindByIdInvalid()
        {
            var service = new ServiceAdditionalServiceShipment(unitOfWork.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceAdditionalServiceShipmentGetAll()
        {
            var service = new ServiceAdditionalServiceShipment(unitOfWork.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<AdditionalServiceShipment>>(result);
            Assert.Equal<int>(5, resultList.Count);
        }

        [Fact]
        public void TestServiceAdditionalServiceShipmentAdd()
        {
            var service = new ServiceAdditionalServiceShipment(unitOfWork.Object);
            var newAdditionalServiceShipment = new AdditionalServiceShipment
            {
                AdditionalServiceId = 1,
                AdditionalService = unitOfWork.Object.AdditionalService.FindByID(1),
                ShipmentId = 2,
                Shipment = unitOfWork.Object.Shipment.FindByID(2)
            };
            service.Add(newAdditionalServiceShipment);
            var additionalServiceShipment = service.FindByID(1, new int[] { 2 });
            Assert.Equal(1, additionalServiceShipment.AdditionalServiceId);
            Assert.Equal(2, additionalServiceShipment.ShipmentId);
            unitOfWork.Verify(x => x.AdditionalServiceShipment.Add(It.Is<AdditionalServiceShipment>(p => p.AdditionalServiceId == 1)), Times.Once);
            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Fact]
        public void TestServiceAdditionalServiceShipmentAddInvalidId()
        {
            var service = new ServiceAdditionalServiceShipment(unitOfWork.Object);
            var newAdditionalServiceShipment = new AdditionalServiceShipment
            {
                AdditionalServiceId = 1,
                AdditionalService = unitOfWork.Object.AdditionalService.FindByID(1),
                ShipmentId = -2,
                Shipment = unitOfWork.Object.Shipment.FindByID(-2)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(newAdditionalServiceShipment));
            unitOfWork.Verify(x => x.AdditionalServiceShipment.Add(It.IsAny<AdditionalServiceShipment>()), Times.Never);
            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }

        [Fact]
        public void TestServiceAdditionalServiceShipmentAddAlreadyExist()
        {
            var service = new ServiceAdditionalServiceShipment(unitOfWork.Object);
            var newAdditionalServiceShipment = new AdditionalServiceShipment
            {
                AdditionalServiceId = 1,
                AdditionalService = unitOfWork.Object.AdditionalService.FindByID(1),
                ShipmentId = 1,
                Shipment = unitOfWork.Object.Shipment.FindByID(1)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(newAdditionalServiceShipment));
            unitOfWork.Verify(x => x.AdditionalServiceShipment.Add(It.IsAny<AdditionalServiceShipment>()), Times.Never);
            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }
    }
}
