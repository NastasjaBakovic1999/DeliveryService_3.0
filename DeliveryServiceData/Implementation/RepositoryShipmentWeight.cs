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

        public void Add(ShipmentWeight param)
        {
            throw new NotImplementedException();
        }

        public void Delete(ShipmentWeight param)
        {
            throw new NotImplementedException();
        }

        public ShipmentWeight FindByID(int id, params int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<ShipmentWeight> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
