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

        public ServiceShipment(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Shipment shipment)
        {
            if (!IsValid(shipment) || !IsValidPostalCode(shipment.Sending.PostalCode) || !IsValidPostalCode(shipment.Receiving.PostalCode) || !IsValidPhoneNumber(shipment.ContactPersonPhone))
            {
                throw new ArgumentOutOfRangeException("Nevalidan unos!");
            }

            unitOfWork.Shipment.Add(shipment);
            unitOfWork.Commit();
        }

        private bool IsValid(Shipment shipment)
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

        public Shipment FindByCode(string code)
        {
            return unitOfWork.Shipment.FindByCode(code);
        }

        public Shipment FindByID(int id, params int[] ids)
        {
            return unitOfWork.Shipment.FindByID(id, ids);
        }

        public List<Shipment> GetAll()
        {
            return unitOfWork.Shipment.GetAll();
        }

        public List<Shipment> GetAllOfSpecifiedUser(int? userId)
        {
            return unitOfWork.Shipment.GetAllOfSpecifiedUser(userId);
        }
    }
}
