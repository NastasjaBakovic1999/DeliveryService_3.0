using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryDeliverer:IRepository<Deliverer>
    {
        public void Add(Deliverer deliverer);
        public void Delete(Deliverer deliverer);
    }
}
