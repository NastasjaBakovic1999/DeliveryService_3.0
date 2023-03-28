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
    public class StatusServiceTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();
        IMapper mapper = Mocks.GetMockAutoMapper();

        [Fact]
        public void TestServiceStatusFindById()
        {
            var service = new ServiceStatus(unitOfWork.Object, mapper);
            var result = service.FindByID(1);
            var resultStatus = Assert.IsType<StatusDto>(result);
            var expected = mapper.Map< StatusDto>(unitOfWork.Object.Status.FindOneByExpression(x => x.StatusId == 1));
            Assert.Equal(expected.StatusId, resultStatus.StatusId);
        }

        [Fact]
        public void TestServiceStatusFindByIdInvalid()
        {
            var service = new ServiceStatus(unitOfWork.Object, mapper);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceStatusGetAll()
        {
            var service = new ServiceStatus(unitOfWork.Object, mapper);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<StatusDto>>(result);
            var expected = mapper.Map<List<StatusDto>>(unitOfWork.Object.Status.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }

        [Fact]
        public void TestServiceStatusGetByName()
        {
            var service = new ServiceStatus(unitOfWork.Object, mapper);
            var status = mapper.Map<StatusDto>(unitOfWork.Object.Status.FindOneByExpression(x => x.StatusId == 1));
            var result = service.GetByName(status.StatusName);

            Assert.Equal(status.StatusId, result.StatusId);
            Assert.Equal(status.StatusName, result.StatusName);
        }

        [Fact]
        public void TestServiceStatusGetByNameNull()
        {
            var service = new ServiceStatus(unitOfWork.Object, mapper);
            var result = service.GetByName("");

            Assert.Null(result);
        }
    }
}
