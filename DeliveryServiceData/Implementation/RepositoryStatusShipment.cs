using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryStatusShipment : GenericRepository<StatusShipment>, IRepositoryStatusShipment
    {
        public RepositoryStatusShipment(DbContext context):base(context)
        {

        }

        public void Add(StatusShipment statusShipment)
        {
            Context.Set<StatusShipment>().Add(statusShipment);
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            return Context.Set<StatusShipment>().Where(sh => sh.ShipmentId == shipmentId).ToList();
        }
    }
}