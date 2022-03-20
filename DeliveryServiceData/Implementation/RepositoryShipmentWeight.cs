using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    internal class RepositoryShipmentWeight : IRepositoryShipmentWeight
    {
        private readonly DeliveryServiceContext context;

        public RepositoryShipmentWeight(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(ShipmentWeight entity)
        {
            context.ShipmentWeights.Add(entity);
        }

        public void Delete(ShipmentWeight entity)
        {
            context.ShipmentWeights.Remove(entity);
        }

        public ShipmentWeight FindByID(int id, params int[] ids)
        {
            return context.ShipmentWeights.Find(id);
        }

        public List<ShipmentWeight> GetAll()
        {
            return context.ShipmentWeights.ToList();
        }
    }
}
