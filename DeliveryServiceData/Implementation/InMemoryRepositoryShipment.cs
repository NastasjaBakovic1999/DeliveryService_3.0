using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryShipment : IRepositoryShipment
    {
        private List<Shipment> shipments = new List<Shipment>();

        public InMemoryRepositoryShipment()
        {

        }
        public void Add(Shipment shipment)
        {
            shipments.Add(shipment);
        }

        public Shipment FindOneByExpression(Expression<Func<Shipment, bool>> expression)
        {
            return shipments.SingleOrDefault(expression.Compile());
        }

        public List<Shipment> GetAll()
        {
            return shipments;
        }

        public List<Shipment> GetAllOfSpecifiedUser(int? userId)
        {
            return shipments.Where(s => s.CustomerId == userId).ToList();
        }
    }
}
