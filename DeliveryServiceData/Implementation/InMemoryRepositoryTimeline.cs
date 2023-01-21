using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryTimeline : IRepositoryTimeline
    {

        private List<Timeline> timelines = new List<Timeline>();

        public InMemoryRepositoryTimeline()
        {

        }

        public Timeline FindOneByExpression(Expression<Func<Timeline, bool>> expression)
        {
            return timelines.SingleOrDefault(expression.Compile());
        }

        public List<Timeline> GetAll()
        {
            return timelines;
        }

        public List<Timeline> GetAllFromProcedure(int ShipmentId)
        {
            throw new NotImplementedException();
        }
    }
}
