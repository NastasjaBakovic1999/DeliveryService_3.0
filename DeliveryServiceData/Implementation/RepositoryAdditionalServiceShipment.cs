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
            context.AdditionalServiceShipments.Add(additionalServiceShipment);
        }

        public void Delete(AdditionalServiceShipment additionalServiceShipment)
        {
            context.AdditionalServiceShipments.Remove(additionalServiceShipment);
        }

        public AdditionalServiceShipment FindByID(int id, params int[] ids)
        {
            return context.AdditionalServiceShipments.Find(id, ids[0]);
        }

        public List<AdditionalServiceShipment> GetAll()
        {
            return context.AdditionalServiceShipments.ToList();
        }

        public void Edit(AdditionalServiceShipment additionalServiceShipment)
        {
            context.AdditionalServiceShipments.Update(additionalServiceShipment);
        }

        public List<AdditionalServiceShipment> GetByShipmentId(int shipmentId)
        {
            return context.AdditionalServiceShipments.Where(ass => ass.ShipmentId == shipmentId).ToList();
        }

        public List<AdditionalServiceShipment> Search(Expression<Func<AdditionalServiceShipment, bool>> pred)
        {
            return context.AdditionalServiceShipments.Where(pred).ToList();
        }
    }
}
