using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryShipment : IRepositoryShipment
    {
        private List<Shipment> shipments = new List<Shipment>();

        public InMemoryRepositoryShipment()
        {

        }
        public void Add(Shipment shipment)
        {
            shipments.Add(shipment);
        }

        public Shipment FindByCode(string code)
        {
            return shipments.Find(s => s.ShipmentCode == code);
        }

        public Shipment FindByID(int id, params int[] ids)
        {
            return shipments.Find(s => s.ShipmentId == id);
        }

        public List<Shipment> GetAll()
        {
            return shipments;
        }

        public List<Shipment> GetAllOfSpecifiedUser(int? userId)
        {
            return shipments.Where(s => s.CustomerId == userId).ToList();
        }
    }
}
