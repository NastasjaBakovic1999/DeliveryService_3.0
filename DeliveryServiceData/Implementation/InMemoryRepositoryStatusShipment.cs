using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryStatusShipment : IRepositoryStatusShipment
    {
        private List<StatusShipment> statusShipments = new List<StatusShipment>();

        public InMemoryRepositoryStatusShipment()
        {

        }

        public void Add(StatusShipment statusShipment)
        {
            statusShipments.Add(statusShipment);
        }

        public StatusShipment FindOneByExpression(Expression<Func<StatusShipment, bool>> expression)
        {
            return statusShipments.SingleOrDefault(expression.Compile());
        }

        public List<StatusShipment> GetAll()
        {
            return statusShipments;
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            return statusShipments.Where(s => s.ShipmentId == shipmentId).ToList();
        }
    }
}
