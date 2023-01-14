using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryShipmentWeight : IRepositoryShipmentWeight
    {
        private List<ShipmentWeight> shipmentWeights = new List<ShipmentWeight>();

        public InMemoryRepositoryShipmentWeight()
        {

        }

        public ShipmentWeight FindOneByExpression(Expression<Func<ShipmentWeight, bool>> expression)
        {
            return shipmentWeights.SingleOrDefault(expression.Compile());
        }

        public List<ShipmentWeight> GetAll()
        {
            return shipmentWeights;
        }
    }
}
