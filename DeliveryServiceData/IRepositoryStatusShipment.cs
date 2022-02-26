using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryStatusShipment : IRepository<StatusShipment>
    {
        public void Edit(StatusShipment statusShipment);

        public List<StatusShipment> GetAllByShipmentId(int shipmentId);
    }
}
