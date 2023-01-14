using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryShipment : GenericRepository<Shipment>, IRepositoryShipment
    {
        public RepositoryShipment(DbContext context) : base(context)
        {
        }

        public void Add(Shipment shipment)
        {
            Context.Set<Shipment>().Add(shipment);
        }

        public List<Shipment> GetAllOfSpecifiedUser(int? userId)
        {
            return Context.Set<Shipment>().Where(sh => sh.CustomerId == userId).ToList();
        }
    }
}
