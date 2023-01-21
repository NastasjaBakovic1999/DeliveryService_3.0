using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryTimeline : GenericRepository<Timeline>, IRepositoryTimeline
    {
        public RepositoryTimeline(DbContext context) : base(context)
        {
        }

        public List<Timeline> GetAllFromProcedure(int shipmentId)
        {
            return Context.Set<Timeline>().FromSqlRaw<Timeline>("GetStatusesTimeline {0}", shipmentId).ToList();
        }
    }
}
