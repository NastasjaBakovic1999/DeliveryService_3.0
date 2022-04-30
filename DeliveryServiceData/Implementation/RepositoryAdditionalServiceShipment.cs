using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryAdditionalServiceShipment : IRepositoryAdditionalServiceShipment
    {
        private readonly DeliveryServiceContext context;

        public RepositoryAdditionalServiceShipment(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(AdditionalServiceShipment additionalServiceShipment)
        {
            try
            {
                context.AdditionalServiceShipments.Add(additionalServiceShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom čuvanja pošiljke i njene dodatne usluge! Greška: {ex.Message}");
            }
        }

        public void Delete(AdditionalServiceShipment additionalServiceShipment)
        {
            try
            {
                context.AdditionalServiceShipments.Remove(additionalServiceShipment);
            }
            catch(Exception ex)
            {
                throw new Exception($"Greška prilikom brisanja pošiljke i njene dodatne uluge! Greška: {ex.Message}");
            }
        }

        public AdditionalServiceShipment FindByID(int id, params int[] ids)
        {
            try
            {
                return context.AdditionalServiceShipments.Find(id, ids[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja pošiljke i njene dodatne uluge! Greška: {ex.Message}");
            }
        }

        public List<AdditionalServiceShipment> GetAll()
        {
            try
            {
               return context.AdditionalServiceShipments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom vraćanja svih pošiljki i njihovih dodatnih uluga! Greška: {ex.Message}");
            }
        }

        public void Edit(AdditionalServiceShipment additionalServiceShipment)
        {
            try
            {
                context.AdditionalServiceShipments.Update(additionalServiceShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom promene podataka pošiljke i njene dodatne uluge! Greška: {ex.Message}");
            }
        }

        public List<AdditionalServiceShipment> GetByShipmentId(int shipmentId)
        {
            try
            {
                 return context.AdditionalServiceShipments.Where(ass => ass.ShipmentId == shipmentId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja pošiljki i njihovih dodatnih uluga na osnovu id-ja pošiljke! Greška: {ex.Message}");
            }
        }

        public List<AdditionalServiceShipment> Search(Expression<Func<AdditionalServiceShipment, bool>> pred)
        {
            try
            {
               return context.AdditionalServiceShipments.Where(pred).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom pretrage pošiljaka i njihovih dodatnih uluga! Greška: {ex.Message}");
            }
        }
    }
}
