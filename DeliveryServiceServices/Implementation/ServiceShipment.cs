using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DeliveryServiceApp.Services.Implementation
{
    public class ServiceShipment : IServiceShipment
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServiceShipment(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(ShipmentDto shipment)
        {
            if (!IsValid(shipment) || !IsValidPostalCode(shipment.Sending.PostalCode) || !IsValidPostalCode(shipment.Receiving.PostalCode) || !IsValidPhoneNumber(shipment.ContactPersonPhone))
            {
                throw new ArgumentOutOfRangeException("Nevalidan unos!");
            }

            unitOfWork.Shipment.Add(mapper.Map<Shipment>(shipment));
            unitOfWork.Commit();
        }

        private bool IsValid(ShipmentDto shipment)
        {
            bool valid = true;

            if (shipment == null) return false;
            if (string.IsNullOrEmpty(shipment.ShipmentCode) || string.IsNullOrEmpty(shipment.ShipmentContent) || string.IsNullOrEmpty(shipment.Sending.City) ||
                string.IsNullOrEmpty(shipment.Sending.Street) || string.IsNullOrEmpty(shipment.Sending.PostalCode) || string.IsNullOrEmpty(shipment.Receiving.City) ||
                string.IsNullOrEmpty(shipment.Receiving.PostalCode) || string.IsNullOrEmpty(shipment.Receiving.Street) || string.IsNullOrEmpty(shipment.ContactPersonName) ||
                string.IsNullOrEmpty(shipment.ContactPersonPhone)) 
            {
                return false;
            }

            if (shipment.ShipmentWeightId == 0 || shipment.CustomerId == 0 || shipment.DelivererId == 0) return false;
            if (shipment.Price == 0 || shipment.Price < 0) return false;

            return valid;
        }

        public bool IsValidPostalCode(string code)
        {
            bool valid = true;

            if (code != null)
            {
                if (!Regex.IsMatch(code.ToString(), "^[0-9]{5,5}$"))
                {
                    valid = false;
                }
            }

            return valid;
        }

        public bool IsValidPhoneNumber(string phone)
        {
            bool valid = true;

            if (phone != null)
            {
                if (!Regex.IsMatch(phone.ToString(), "^06[0-9]{7,9}$"))
                {
                    valid = false;
                }
            }

            return valid;
        }

        public ShipmentDto FindByCode(string code)
        {
            var shipment = unitOfWork.Shipment.FindByCode(code);
            return mapper.Map<ShipmentDto>(shipment);
        }

        public ShipmentDto FindByID(int id, params int[] ids)
        {
            var shipment = unitOfWork.Shipment.FindByID(id, ids);
            return mapper.Map<ShipmentDto>(shipment);
        }

        public List<ShipmentDto> GetAll()
        {
            var shipments = unitOfWork.Shipment.GetAll();
            return mapper.Map<List<ShipmentDto>>(shipments);
        }

        public List<ShipmentDto> GetAllOfSpecifiedUser(int? userId)
        {
            var shipments = unitOfWork.Shipment.GetAllOfSpecifiedUser(userId);
            return mapper.Map<List<ShipmentDto>>(shipments);
        }
    }
}
