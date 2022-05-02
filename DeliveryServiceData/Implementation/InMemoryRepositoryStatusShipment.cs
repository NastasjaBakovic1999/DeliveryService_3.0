using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryStatusShipment : IRepositoryStatusShipment
    {
        private List<StatusShipment> statusShipments = new List<StatusShipment>();

        public InMemoryRepositoryStatusShipment()
        {

        }

        public void Add(StatusShipment statusShipment)
        {
            statusShipments.Add(statusShipment);
        }

        public StatusShipment FindByID(int id, params int[] ids)
        {
            return statusShipments.Find(s => s.StatusId == id && s.ShipmentId == ids[0]);
        }

        public List<StatusShipment> GetAll()
        {
            return statusShipments;
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            return statusShipments.Where(s => s.ShipmentId == shipmentId).ToList();
        }
    }
}
