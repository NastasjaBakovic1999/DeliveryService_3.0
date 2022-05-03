using DeliveryServiceApp.Services.Implementation;
using DeliveryServiceData;
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
    public class ShipmentTests
    {
        Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();
        Mock<IRepositoryCustomer> customerRepository = Mocks.GetMockCustomerRepository();
        Mock<IRepositoryDeliverer> delivererRepository = Mocks.GetMockDelivererRepository();
        Mock<IRepositoryShipmentWeight> shipmentWeightRepository = Mocks.GetMockShipmentWeightRepository();

        [Fact]
        public void TestServiceShipmentFindById()
        {
            var service = new ServiceShipment(unitOfWork.Object);
            var result = service.FindByID(1);
            var resultShipment = Assert.IsType<Shipment>(result);
            var expected = unitOfWork.Object.Shipment.FindByID(1);
            Assert.Equal(expected.ShipmentId, resultShipment.ShipmentId);
        }

        [Fact]
        public void TestServiceShipmentFindByIdInvalid()
        {
            var service = new ServiceShipment(unitOfWork.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceShipmentGetAll()
        {
            var service = new ServiceShipment(unitOfWork.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<Shipment>>(result);
            Assert.Equal<int>(3, resultList.Count);
        }

        [Fact]
        public void TestServiceShipmentAdd()
        {
            Random rand = new Random();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            var service = new ServiceShipment(unitOfWork.Object);
            var newShipment = new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8",
                ShipmentWeight = shipmentWeightRepository.Object.FindByID(1),
                Customer = customerRepository.Object.FindByID(4),
                Deliverer = delivererRepository.Object.FindByID(3)
            };
            service.Add(newShipment);
            var shipment = service.FindByID(4);
            Assert.Equal(shipment.ShipmentCode, newShipment.ShipmentCode);
            Assert.Equal(shipment.ShipmentContent, newShipment.ShipmentContent);
            Assert.Equal(shipment.SendingCity, newShipment.SendingCity);
            Assert.Equal(shipment.SendingAddress, newShipment.SendingAddress);
            Assert.Equal(shipment.SendingPostalCode, newShipment.SendingPostalCode);
            Assert.Equal(shipment.ReceivingCity, newShipment.ReceivingCity);
            Assert.Equal(shipment.ReceivingAddress, newShipment.ReceivingAddress);
            Assert.Equal(shipment.ReceivingPostalCode, newShipment.ReceivingPostalCode);
            Assert.Equal(shipment.ContactPersonName, newShipment.ContactPersonName);
            Assert.Equal(shipment.ContactPersonPhone, newShipment.ContactPersonPhone);
            Assert.Equal(shipment.Note, newShipment.Note);
            Assert.Equal(shipment.ShipmentWeightId, newShipment.ShipmentWeightId);
            Assert.Equal(shipment.CustomerId, newShipment.CustomerId);
            Assert.Equal(shipment.DelivererId, newShipment.DelivererId);
            Assert.Equal(shipment.Price, newShipment.Price);
            unitOfWork.Verify(x => x.Shipment.Add(It.Is<Shipment>(p => p.ShipmentId == 4)), Times.Once);
            unitOfWork.Verify(s => s.Commit(), Times.Once);
        }

        [Theory]
        [MemberData(nameof(ShipmentData))]
        public void TestServiceShipmentAddEmptyProps(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(newShipment));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataIds))]
        public void TestServiceShipmentAddZeroIds(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(newShipment));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataPrice))]
        public void TestServiceShipmentAddInvalidPrice(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(newShipment));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataPostalCode))]
        public void TestServiceShipmentAddInvalidPostalCode(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(newShipment));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataPhoneNumber))]
        public void TestServiceShipmentAddInvalidPhoneNumber(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(newShipment));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Fact]
        public void TestServiceShipmentGetAllOfSpecifiedUser()
        {
            var service = new ServiceShipment(unitOfWork.Object);
            var result = service.GetAllOfSpecifiedUser(3);
            var resultList = Assert.IsAssignableFrom<List<Shipment>>(result);
            Assert.Equal<int>(2, resultList.Count);
        }

        [Fact]
        public void TestServiceShipmentGetAllOfSpecifiedUserNull()
        {
            var service = new ServiceShipment(unitOfWork.Object);
            var result = service.GetAllOfSpecifiedUser(0);

            Assert.Empty(result);
        }

        [Fact]
        public void TestServiceShipmentFindByCode()
        {
            var service = new ServiceShipment(unitOfWork.Object);
            var shipment = service.FindByID(1);
            var result = service.FindByCode(shipment.ShipmentCode);

            Assert.Equal(shipment.ShipmentId, result.ShipmentId);
            Assert.Equal(shipment.ShipmentCode, result.ShipmentCode);
            Assert.Equal(shipment.ShipmentContent, result.ShipmentContent);
            Assert.Equal(shipment.SendingCity, result.SendingCity);
            Assert.Equal(shipment.SendingAddress, result.SendingAddress);
            Assert.Equal(shipment.SendingPostalCode, result.SendingPostalCode);
            Assert.Equal(shipment.ReceivingCity, result.ReceivingCity);
            Assert.Equal(shipment.ReceivingAddress, result.ReceivingAddress);
            Assert.Equal(shipment.ReceivingPostalCode, result.ReceivingPostalCode);
            Assert.Equal(shipment.ContactPersonName, result.ContactPersonName);
            Assert.Equal(shipment.ContactPersonPhone, result.ContactPersonPhone);
            Assert.Equal(shipment.Note, result.Note);
            Assert.Equal(shipment.ShipmentWeightId, result.ShipmentWeightId);
            Assert.Equal(shipment.CustomerId, result.CustomerId);
            Assert.Equal(shipment.DelivererId, result.DelivererId);
            Assert.Equal(shipment.Price, result.Price);
        }

        [Fact]
        public void TestServiceShipmentFindByCodeNull()
        {
            var service = new ServiceShipment(unitOfWork.Object);
            var result = service.FindByCode("");

            Assert.Null(result);
        }

        public static IEnumerable<object[]> ShipmentData()
        {
            Random rand = new Random();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            }};
            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            }};
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8",
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8",
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8",
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8",
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8",
            } };

        }

        public static IEnumerable<object[]> ShipmentDataIds()
        {
            Random rand = new Random();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            }};
            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                Price = 330,
                Note = "stan 8"
            } };

        }

        public static IEnumerable<object[]> ShipmentDataPrice()
        {
            Random rand = new Random();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Note = "stan 8"
            }};
            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = -20,
                Note = "stan 8"
            } };
        }

        public static IEnumerable<object[]> ShipmentDataPhoneNumber()
        {
            Random rand = new Random();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "+381654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            }};
            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11060",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654477889908",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
        }

        public static IEnumerable<object[]> ShipmentDataPostalCode()
        {
            Random rand = new Random();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "1106",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            }};
            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "110600",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "postanski broj",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "76322",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11000",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "7632",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11000",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "763299",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };
            yield return new object[] { new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                SendingCity = "Beograd",
                SendingAddress = "Arsenija Carnojevica 17",
                SendingPostalCode = "11000",
                ReceivingCity = "Kragujevac",
                ReceivingAddress = "Jablanicka 13",
                ReceivingPostalCode = "broj",
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8"
            } };

        }
    }
}
