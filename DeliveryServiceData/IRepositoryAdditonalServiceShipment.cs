using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryAdditionalServiceShipment : IRepository<AdditionalServiceShipment>
    {
        public void Edit(AdditionalServiceShipment additionalServiceShipment);
        public List<AdditionalServiceShipment> GetByShipmentId(int shipmentId);
        public List<AdditionalServiceShipment> Search(Expression<Func<AdditionalServiceShipment, bool>> pred);
    }
}
