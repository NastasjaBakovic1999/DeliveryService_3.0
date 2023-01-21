using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryTimeline : IRepository<Timeline>
    {
        public List<Timeline> GetAllFromProcedure(int ShipmentId);
    }
}
