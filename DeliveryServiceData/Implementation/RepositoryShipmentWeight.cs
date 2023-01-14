using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    internal class RepositoryShipmentWeight : GenericRepository<ShipmentWeight>, IRepositoryShipmentWeight
    {
        public RepositoryShipmentWeight(DbContext context) : base(context)
        {

        }
    }
}
