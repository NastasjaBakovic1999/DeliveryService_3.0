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

        public void Add(Shipment param)
        {
            throw new NotImplementedException();
        }

        public void Delete(Shipment param)
        {
            throw new NotImplementedException();
        }

        public Shipment FindByID(int id, params int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<Shipment> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
