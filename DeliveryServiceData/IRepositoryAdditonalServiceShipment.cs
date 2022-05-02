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
        public void Add(AdditionalServiceShipment additionalServiceShipment);
        
    }
}
