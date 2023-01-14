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
        IMapper mapper = Mocks.GetMockAutoMapper();

        [Fact]
        public void TestServiceStatusShipmentFindById()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper);
            var result = service.FindByID(1, 1);
            var resultStatus = Assert.IsType<StatusShipmentDto>(result);
            var expected = mapper.Map<StatusShipmentDto>(unitOfWork.Object.StatusShipment.FindOneByExpression(x=> x.StatusId == 1 && x.ShipmentId == 1));
            Assert.Equal(expected.StatusId, resultStatus.StatusId);
            Assert.Equal(expected.ShipmentId, resultStatus.ShipmentId);
            Assert.Equal(expected.StatusTime, resultStatus.StatusTime);
        }

        [Fact]
        public void TestServiceStatusShipmentFindByIdInvalid()
        {
            var service = new ServiceStatus(unitOfWork.Object, mapper);
            var result = service.FindByID(-4, 1);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceStatusShipmentGetAll()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<StatusShipmentDto>>(result);
            var expected = mapper.Map<List<StatusShipmentDto>>(unitOfWork.Object.StatusShipment.GetAll());
            Assert.Equal<int>(expected.Count, resultList.Count);
        }

        [Fact]
        public void TestServiceStatusShipmentAdd()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper);
            var newStatusShipment = new StatusShipment
            {
                StatusId = 6,
                Status = unitOfWork.Object.Status.FindOneByExpression(x => x.StatusId == 6),
                ShipmentId = 2,
                Shipment = unitOfWork.Object.Shipment.FindOneByExpression(x=> x.ShipmentId == 2),
                StatusTime = DateTime.Now
            };
            service.Add(mapper.Map<StatusShipmentDto>(newStatusShipment));
            var statusShipment = unitOfWork.Object.StatusShipment.FindOneByExpression(x => x.ShipmentId == 2 && x.StatusId == 6);
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
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Map<StatusShipmentDto>(newStatusShipment)));
            unitOfWork.Verify(x => x.StatusShipment.Add(It.IsAny<StatusShipment>()), Times.Never);
            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }

        [Fact]
        public void TestServiceStatusShipmentAddAlreadyExist()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper);
            var newStatusShipment = new StatusShipment
            {
                StatusId = 1,
                Status = unitOfWork.Object.Status.FindOneByExpression(x=>x.StatusId == 1),
                ShipmentId = 1,
                Shipment = unitOfWork.Object.Shipment.FindOneByExpression(x=> x.ShipmentId ==1)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Map<StatusShipmentDto>(newStatusShipment)));
            unitOfWork.Verify(x => x.StatusShipment.Add(It.IsAny<StatusShipment>()), Times.Never);
            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }

        [Fact]
        public void TestServiceStatusShipmentGetAllByShipmentId()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper);
            var result = service.GetAllByShipmentId(2);
            var resultList = Assert.IsAssignableFrom<List<StatusShipmentDto>>(result);
            var expected = mapper.Map<List<StatusShipmentDto>>(unitOfWork.Object.StatusShipment.GetAllByShipmentId(2));
            Assert.Equal(expected.Count, resultList.Count);
        }

        [Fact]
        public void TestServiceStatusShipmentGetAllByShipmentIdNull()
        {
            var service = new ServiceStatusShipment(unitOfWork.Object, mapper);
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
