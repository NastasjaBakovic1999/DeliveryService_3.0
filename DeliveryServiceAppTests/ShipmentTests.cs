using AutoMapper;
using DataTransferObjects;
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
        readonly Mock<IUnitOfWork> unitOfWork = Mocks.GetMockUnitOfWork();
        readonly Mock<IRepositoryCustomer> customerRepository = Mocks.GetMockCustomerRepository();
        readonly Mock<IRepositoryDeliverer> delivererRepository = Mocks.GetMockDelivererRepository();
        readonly Mock<IRepositoryShipmentWeight> shipmentWeightRepository = Mocks.GetMockShipmentWeightRepository();
        Mock<IMapper> mapper = new();

        [Fact]
        public void TestServiceShipmentFindById()
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var result = service.FindByID(1);
            var resultShipment = Assert.IsType<ShipmentDto>(result);
            var expected = mapper.Object.Map<ShipmentDto>(unitOfWork.Object.Shipment.FindByID(1));
            Assert.Equal(expected.ShipmentId, resultShipment.ShipmentId);
        }

        [Fact]
        public void TestServiceShipmentFindByIdInvalid()
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var result = service.FindByID(-4);

            Assert.Null(result);
        }

        [Fact]
        public void TestServiceShipmentGetAll()
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var result = service.GetAll();
            var resultList = Assert.IsAssignableFrom<List<ShipmentDto>>(result);
            var expected = mapper.Object.Map<List<ShipmentDto>>(unitOfWork.Object.Shipment.GetAll());
            Assert.Equal(expected.Count, resultList.Count);
        }

        [Fact]
        public void TestServiceShipmentAdd()
        {
            Random rand = new();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var newShipment = new Shipment
            {
                ShipmentId = 4,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322",
                },
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
            service.Add(mapper.Object.Map<ShipmentDto>(newShipment));
            var shipment = unitOfWork.Object.Shipment.FindByID(4);
            Assert.Equal(shipment.ShipmentCode, newShipment.ShipmentCode);
            Assert.Equal(shipment.ShipmentContent, newShipment.ShipmentContent);
            Assert.Equal(shipment.Sending.City, newShipment.Sending.City);
            Assert.Equal(shipment.Sending.Street, newShipment.Sending.Street);
            Assert.Equal(shipment.Sending.PostalCode, newShipment.Sending.PostalCode);
            Assert.Equal(shipment.Receiving.City, newShipment.Receiving.City);
            Assert.Equal(shipment.Receiving.Street, newShipment.Receiving.Street);
            Assert.Equal(shipment.Receiving.PostalCode, newShipment.Receiving.PostalCode);
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
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Object.Map<ShipmentDto>(newShipment)));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataIds))]
        public void TestServiceShipmentAddZeroIds(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Object.Map<ShipmentDto>(newShipment)));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataPrice))]
        public void TestServiceShipmentAddInvalidPrice(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Object.Map<ShipmentDto>(newShipment)));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataPostalCode))]
        public void TestServiceShipmentAddInvalidPostalCode(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Object.Map<ShipmentDto>(newShipment)));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ShipmentDataPhoneNumber))]
        public void TestServiceShipmentAddInvalidPhoneNumber(Shipment newShipment)
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.Add(mapper.Object.Map<ShipmentDto>(newShipment)));
            unitOfWork.Verify(x => x.Shipment.Add(It.IsAny<Shipment>()), Times.Never);
            unitOfWork.Verify(s => s.Commit(), Times.Never);
        }

        [Fact]
        public void TestServiceShipmentGetAllOfSpecifiedUser()
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var result = service.GetAllOfSpecifiedUser(3);
            var resultList = Assert.IsAssignableFrom<List<ShipmentDto>>(result);
            Assert.Equal(2, resultList.Count);
        }

        [Fact]
        public void TestServiceShipmentGetAllOfSpecifiedUserNull()
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var result = service.GetAllOfSpecifiedUser(0);

            Assert.Empty(result);
        }

        [Fact]
        public void TestServiceShipmentFindByCode()
        {
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var shipment = service.FindByID(1);
            var result = service.FindByCode(shipment.ShipmentCode);

            Assert.Equal(shipment.ShipmentId, result.ShipmentId);
            Assert.Equal(shipment.ShipmentCode, result.ShipmentCode);
            Assert.Equal(shipment.ShipmentContent, result.ShipmentContent);
            Assert.Equal(shipment.Sending.City, result.Sending.City);
            Assert.Equal(shipment.Sending.Street, result.Sending.Street);
            Assert.Equal(shipment.Sending.PostalCode, result.Sending.PostalCode);
            Assert.Equal(shipment.Receiving.City, result.Receiving.City);
            Assert.Equal(shipment.Receiving.Street, result.Receiving.Street);
            Assert.Equal(shipment.Receiving.PostalCode, result.Receiving.PostalCode);
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
            var service = new ServiceShipment(unitOfWork.Object, mapper.Object);
            var result = service.FindByCode("");

            Assert.Null(result);
        }

        public static IEnumerable<object[]> ShipmentData()
        {
            Random rand = new();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentWeightId = 1,
                ShipmentContent = "racunar",
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060"
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322",
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060"
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322",
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    PostalCode = "11060"
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    Street = "Jablanicka 13",
                    PostalCode = "76322",
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    PostalCode = "76322",
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322",
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322",
                },
                ContactPersonName = "Marko Markovic",
                CustomerId = 4,
                DelivererId = 3,
                Price = 330,
                Note = "stan 8",
            } };
            yield return new object[] { null };

        }

        public static IEnumerable<object[]> ShipmentDataIds()
        {
            Random rand = new();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                     City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                     City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                     City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
                ContactPersonName = "Marko Markovic",
                ContactPersonPhone = "0654433221",
                CustomerId = 4,
                Price = 330,
                Note = "stan 8"
            } };

        }

        public static IEnumerable<object[]> ShipmentDataPrice()
        {
            Random rand = new();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                     City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                     City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
            Random rand = new();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
            Random rand = new();
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            yield return new object[] {  new Shipment
            {
                ShipmentId = 4,
                ShipmentContent = "racunar",
                ShipmentWeightId = 1,
                ShipmentCode = new string(Enumerable.Repeat(chars, 11).Select(s => s[rand.Next(chars.Length)]).ToArray()),
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "1106",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "110600",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "postanski broj",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "76322"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "7632"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "7632299"
                },
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
                Sending = new Address
                {
                    City = "Beograd",
                    Street = "Arsenija Carnojevica 17",
                    PostalCode = "11060",
                },
                Receiving = new Address
                {
                    City = "Kragujevac",
                    Street = "Jablanicka 13",
                    PostalCode = "broj"
                },
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
