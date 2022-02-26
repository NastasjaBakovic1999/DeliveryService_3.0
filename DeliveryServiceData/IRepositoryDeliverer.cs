using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryDeliverer : IRepository<Deliverer>
    {
        public Deliverer GetByUsernameAndPassword(Deliverer deliverer);

        public Deliverer Search(Expression<Func<Deliverer, bool>> pred);
    }
}
