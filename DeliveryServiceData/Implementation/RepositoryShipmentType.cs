using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryShipmentType : IRepositoryShipmentType
    {
        private readonly DeliveryServiceContext context;

        public RepositoryShipmentType(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(ShipmentType param)
        {
            throw new NotImplementedException();
        }

        public void Delete(ShipmentType param)
        {
            throw new NotImplementedException();
        }

        public ShipmentType FindByID(int id, params int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<ShipmentType> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
