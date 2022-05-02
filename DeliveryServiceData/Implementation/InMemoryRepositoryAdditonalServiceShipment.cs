using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryAdditonalServiceShipment : IRepositoryAdditionalServiceShipment
    {
        private List<AdditionalServiceShipment> additionalServiceShipments = new List<AdditionalServiceShipment>();

        public void Add(AdditionalServiceShipment additionalServiceShipment)
        {
            additionalServiceShipments.Add(additionalServiceShipment);
        }

        public AdditionalServiceShipment FindByID(int id, params int[] ids)
        {
            return additionalServiceShipments.Find(a => a.ShipmentId == id && a.AdditionalServiceId == ids[0]);
        }

        public List<AdditionalServiceShipment> GetAll()
        {
            return additionalServiceShipments;
        }
    }
}
