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
            context.StatusShipments.Add(statusShipment);
        }

        public void Delete(StatusShipment statusShipment)
        {
            context.StatusShipments.Remove(statusShipment);
        }

        public StatusShipment FindByID(int id, params int[] ids)
        {
            return context.StatusShipments.Find(id, ids[0]);
        }

        public List<StatusShipment> GetAll()
        {
            return context.StatusShipments.ToList();
        }

        public void Edit(StatusShipment statusShipment)
        {
            context.StatusShipments.Update(statusShipment);
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            return context.StatusShipments.Where(ss => ss.ShipmentId == shipmentId).ToList();
        }
    }
}