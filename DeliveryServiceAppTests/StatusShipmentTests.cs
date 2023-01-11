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
    public class StatusShipmentTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();
        Mock<IMapper> mapper = new();

        [Fact]
        public void TestServiceStatusShipmentFindById()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper.Object);
            var result = service.FindByID(1, 1);
            var resultStatus = Assert.IsType<StatusShipmentDto>(result);
            var expected = mapper.Object.Map<StatusShipmentDto>(unitOfWork.Object.StatusShipment.FindByID(1, 1));
            Assert.Equal(expected.StatusId, resultStatus.StatusId);
            Assert.Equal(expected.ShipmentId, resultStatus.ShipmentId);
            Assert.Equal(expected.StatusTime, resultStatus.StatusTime);
        }

        [Fact]
        public void TestServiceStatusShipmentFindByIdInvalid()
        {
            var service = new ServiceStatus(unitOfWork.Object, mapper.Object);
            var result = service.FindByID(-4, 1);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceStatusShipmentGetAll()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<StatusShipmentDto>>(result);
            var expected = mapper.Object.Map<List<StatusShipmentDto>>(unitOfWork.Object.StatusShipment.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }

        [Fact]
        public void TestServiceStatusShipmentAdd()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper.Object);
            var newStatusShipment = new StatusShipment
            {
                StatusId = 6,
                Status = unitOfWork.Object.Status.FindByID(6),
                ShipmentId = 2,
                Shipment = unitOfWork.Object.Shipment.FindByID(2),
                StatusTime = DateTime.Now
            };
            service.Add(mapper.Object.Map<StatusShipmentDto>(newStatusShipment));
            var statusShipment = unitOfWork.Object.StatusShipment.FindByID(6, new int[] { 2 });
            Assert.Equal(newStatusShipment.StatusId, statusShipment.StatusId);
            Assert.Equal(newStatusShipment.ShipmentId, statusShipment.ShipmentId);
            Assert.Equal(newStatusShipment.StatusTime, statusShipment.StatusTime);

            unitOfWork.Verify(x => x.StatusShipment.Add(It.Is<StatusShipment>(p => p.StatusId == 6 && p.ShipmentId == 2)), Times.Once);
            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Theory]
        [MemberData(nameof(StatusShipmentData))]
        public void TestServiceStatusShipmentAddInvalidId(StatusShipment newStatusShipment)
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Object.Map<StatusShipmentDto>(newStatusShipment)));
            unitOfWork.Verify(x => x.StatusShipment.Add(It.IsAny<StatusShipment>()), Times.Never);
            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }

        [Fact]
        public void TestServiceStatusShipmentAddAlreadyExist()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper.Object);
            var newStatusShipment = new StatusShipment
            {
                StatusId = 1,
                Status = unitOfWork.Object.Status.FindByID(1),
                ShipmentId = 1,
                Shipment = unitOfWork.Object.Shipment.FindByID(1)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Object.Map<StatusShipmentDto>(newStatusShipment)));
            unitOfWork.Verify(x => x.StatusShipment.Add(It.IsAny<StatusShipment>()), Times.Never);
            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }

        [Fact]
        public void TestServiceStatusShipmentGetAllByShipmentId()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper.Object);
            var result = service.GetAllByShipmentId(2);
            var resultList = Assert.IsAssignableFrom<List<StatusShipmentDto>>(result);
            var expected = mapper.Object.Map<List<StatusShipmentDto>>(unitOfWork.Object.StatusShipment.GetAllByShipmentId(2));
            Assert.Equal(expected.Count, resultList.Count);
        }

        [Fact]
        public void TestServiceStatusShipmentGetAllByShipmentIdNull()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper.Object);
            var result = service.GetAllByShipmentId(0);

            Assert.Empty(result);
        }

        public static IEnumerable<object[]> StatusShipmentData()
        {
            yield return new object[] {  new StatusShipment
            {
                StatusId = -1,
                ShipmentId = 3,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 1,
                ShipmentId = -3,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = -2,
                ShipmentId = -4,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 0,
                ShipmentId = -4,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = -2,
                ShipmentId = 0,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 0,
                ShipmentId = 4,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 2,
                ShipmentId = 0,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 0,
                ShipmentId = 0,
                StatusTime = DateTime.Now
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 2,
                ShipmentId = 3,
                StatusTime = DateTime.Now.AddDays(1)
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 2,
                ShipmentId = 3,
                StatusTime = DateTime.Now.AddMonths(1)
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 2,
                ShipmentId = 3,
                StatusTime = DateTime.Now.AddMinutes(5)
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = -2,
                ShipmentId = 3,
                StatusTime = DateTime.Now.AddMonths(1)
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = 2,
                ShipmentId = -3,
                StatusTime = DateTime.Now.AddMonths(1)
            }};
            yield return new object[] {  new StatusShipment
            {
                StatusId = -2,
                ShipmentId = -3,
                StatusTime = DateTime.Now.AddMonths(1)
            }};
            yield return new object[] { null };
        }


    }
}
