using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryShipmentStatusStatistic : IRepositoryShipmentStatusStatistic
    {

        private List<ShipmentStatusStatistic> shipmentStatusStatistics = new List<ShipmentStatusStatistic>();

        public ShipmentStatusStatistic FindOneByExpression(Expression<Func<ShipmentStatusStatistic, bool>> expression)
        {
            return shipmentStatusStatistics.SingleOrDefault(expression.Compile());
        }

        public List<ShipmentStatusStatistic> GetAll()
        {
            return shipmentStatusStatistics;
        }
    }
}
