using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryDeliverer : IRepositoryDeliverer
    {
        private List<Deliverer> deliverers = new List<Deliverer>();

        public InMemoryRepositoryDeliverer()
        {

        }

        public Deliverer FindOneByExpression(Expression<Func<Deliverer, bool>> expression)
        {
            return deliverers.SingleOrDefault(expression.Compile());
        }

        public List<Deliverer> GetAll()
        {
            return deliverers;
        }
    }
}
