using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryStatusShipment : IRepositoryStatusShipment
    {
        private readonly DeliveryServiceContext context;

        public RepositoryStatusShipment(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(StatusShipment statusShipment)
        {
            try
            {
                context.StatusShipments.Add(statusShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom čuvanja novog statusa određenje pošiljke! Greška: {ex.Message}");
            }
        }

        public void Delete(StatusShipment statusShipment)
        {
            try
            {
                context.StatusShipments.Remove(statusShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom brisanja statusa određenje pošiljke! Greška: {ex.Message}");
            }
        }

        public StatusShipment FindByID(int id, params int[] ids)
        {
            try
            {
                return context.StatusShipments.Find(id, ids[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja pošiljke i njenih statusa! Greška: {ex.Message}");
            }
        }

        public List<StatusShipment> GetAll()
        {
            try
            {
                return context.StatusShipments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja svih pošiljki sa njihovim statusima! Greška: {ex.Message}");
            }
        }

        public void Edit(StatusShipment statusShipment)
        {
            try
            {
                context.StatusShipments.Update(statusShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom izmene podataka pošiljke sa njenim statusima! Greška: {ex.Message}");
            }
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            try
            {
                return context.StatusShipments.Where(ss => ss.ShipmentId == shipmentId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja pošiljke i njenih statusa na osnovu id-ja pošiljke! Greška: {ex.Message}");
            }
        }
    }
}