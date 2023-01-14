using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryAdditionalServiceShipment : GenericRepository<AdditionalServiceShipment>, IRepositoryAdditionalServiceShipment
    {
        public RepositoryAdditionalServiceShipment(DbContext context) : base(context)
        {
        }

        public void Add(AdditionalServiceShipment additionalServiceShipment)
        {
            Context.Set<AdditionalServiceShipment>().Add(additionalServiceShipment);
        }
    }
}
