using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    internal class InMemoryRepositoryStatus : IRepositoryStatus
    {
        private List<Status> statuses = new List<Status>();

        public InMemoryRepositoryStatus()
        {

        }

        public Status FindOneByExpression(Expression<Func<Status, bool>> expression)
        {
            return statuses.SingleOrDefault(expression.Compile());
        }

        public List<Status> GetAll()
        {
            return statuses;
        }

    }
}
