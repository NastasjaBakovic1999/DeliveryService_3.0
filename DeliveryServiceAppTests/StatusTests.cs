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
    public class StatusTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();

        [Fact]
        public void TestServiceStatusFindById()
        {
            var service = new ServiceStatus(unitOfWork.Object);
            var result = service.FindByID(1);
            var resultStatus = Assert.IsType<Status>(result);
            var expected = unitOfWork.Object.Status.FindByID(1);
            Assert.Equal(expected.StatusId, resultStatus.StatusId);
        }

        [Fact]
        public void TestServiceStatusFindByIdInvalid()
        {
            var service = new ServiceStatus(unitOfWork.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceStatusGetAll()
        {
            var service = new ServiceStatus(unitOfWork.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<Status>>(result);
            Assert.Equal<int>(6, resultList.Count);
        }

        [Fact]
        public void TestServiceStatusGetByName()
        {
            var service = new ServiceStatus(unitOfWork.Object);
            var status = unitOfWork.Object.Status.FindByID(1);
            var result = service.GetByName(status.StatusName);

            Assert.Equal(status.StatusId, result.StatusId);
            Assert.Equal(status.StatusName, result.StatusName);
        }

        [Fact]
        public void TestServiceStatusGetByNameNull()
        {
            var service = new ServiceStatus(unitOfWork.Object);
            var result = service.GetByName("");

            Assert.Null(result);
        }
    }
}
