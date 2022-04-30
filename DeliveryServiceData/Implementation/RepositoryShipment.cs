using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryShipment : IRepositoryShipment
    {
        private readonly DeliveryServiceContext context;

        public RepositoryShipment(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(Shipment shipment)
        {
            try
            {
                context.Shipments.Add(shipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom čuvanja nove pošiljke! Greška: {ex.Message}");
            }
        }

        public void Delete(Shipment shipment)
        {
            try
            {
                context.Shipments.Remove(shipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom brisanja pošiljke! Greška: {ex.Message}");
            }
        }

        public Shipment FindByID(int id, params int[] ids)
        {
            try
            {
                return context.Shipments.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja pošiljle! Greška: {ex.Message}");
            }
        }

        public List<Shipment> GetAll()
        {
            try
            {
                return context.Shipments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom vraćanja svih pošiljaka! Greška: {ex.Message}");
            }
        }

        public Shipment FindByCode(string code)
        {
            try
            {
                return context.Shipments.Single(s => s.ShipmentCode == code);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja pošiljke na osnovu njenog koda! Greška: {ex.Message}");
            }
        }

        public List<Shipment> GetAllOfSpecifiedUser(int? userId)
        {
            try
            {
                return context.Shipments.Where(s => s.CustomerId == userId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom vraćanja svih pošiljki određenog korisnika! Greška: {ex.Message}");
            }
            
        }

    }
}
