using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryShipment : IRepository<Shipment>
    {
        public List<Shipment> GetAllOfSpecifiedUser(int? userId);
        public List<Shipment> GetAllOfSpecifiedDeliverer(int? delivererId);
    }
}
