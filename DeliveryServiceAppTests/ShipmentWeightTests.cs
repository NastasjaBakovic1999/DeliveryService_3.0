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
    public class ShipmentWeightTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();
        IMapper mapper = Mocks.GetMockAutoMapper();

        [Fact]
        public void TestServiceShipmentWeightFindById()
        {
            var service = new ServiceShipmentWeight(unitOfWork.Object, mapper);
            var result = service.FindByID(1);
            var resultShipmentWeight = Assert.IsType<ShipmentWeightDto>(result);
            var expected = mapper.Map<ShipmentWeightDto>(unitOfWork.Object.ShipmentWeight.FindByID(1));
            Assert.Equal(expected.ShipmentWeightId, resultShipmentWeight.ShipmentWeightId);
        }

        [Fact]
        public void TestServiceShipmentWeightFindByIdInvalid()
        {
            var service = new ServiceShipmentWeight(unitOfWork.Object, mapper);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServicePersonGetAll()
        {
            var service = new ServiceShipmentWeight(unitOfWork.Object, mapper);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<ShipmentWeightDto>>(result);
            var expected = mapper.Map<List<ShipmentWeightDto>>(unitOfWork.Object.ShipmentWeight.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }
    }
}
