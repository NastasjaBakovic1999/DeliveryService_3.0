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
    public class AdditionalServiceTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();
        IMapper mapper = Mocks.GetMockAutoMapper();

        [Fact]
        public void TestServiceAdditionalServiceFindById()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object, mapper);
            var result = service.FindByID(1);
            var resultAdditionalService = Assert.IsType<AdditionalServiceDto>(result);
            var expected = mapper.Map<AdditionalServiceDto>(unitOfWork.Object.AdditionalService.FindByID(1));
            Assert.Equal(expected.AdditionalServiceId, resultAdditionalService.AdditionalServiceId);
        }

        [Fact]
        public void TestServiceAdditionalServiceFindByIdInvalid()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object, mapper);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceAdditionalServiceGetAll()
        {
            var service = new ServiceAdditionalService(unitOfWork.Object, mapper);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<AdditionalServiceDto>>(result);
            var expected = mapper.Map<List<AdditionalServiceDto>>(unitOfWork.Object.AdditionalService.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }

    }
}
