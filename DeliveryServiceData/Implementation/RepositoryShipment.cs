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
            context.Shipments.Add(shipment);
        }

        public void Delete(Shipment shipment)
        {
            context.Shipments.Remove(shipment);
        }

        public Shipment FindByID(int id, params int[] ids)
        {
            return context.Shipments.Find(id);
        }

        public List<Shipment> GetAll()
        {
            return context.Shipments.ToList();
        }

        public Shipment FindByCode(string code)
        {
            return context.Shipments.FirstOrDefault(s => s.ShipmentCode == code);
        }

        public List<Shipment> GetAllOfSpecifiedUser(int? userId)
        {
            if (userId != null)
            {
                return context.Shipments.Where(s => s.CustomerId == userId).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Shipment> GetAllOfSpecifiedDeliverer(int? delivererId)
        {
            if(delivererId != null)
            {
                return context.Shipments.Where(s => s.DelivererId == delivererId).ToList();
            }
            else
            {
                return null;
            }
        }

    }
}
