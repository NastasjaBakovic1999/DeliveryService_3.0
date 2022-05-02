using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ShipmentWeight FindByID(int id, params int[] ids)
        {
            return shipmentWeights.Find(s => s.ShipmentWeightId == id);
        }

        public List<ShipmentWeight> GetAll()
        {
            return shipmentWeights;
        }
    }
}
