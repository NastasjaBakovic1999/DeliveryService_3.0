using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Deliverer FindByID(int id, params int[] ids)
        {
            return deliverers.Find(d => d.Id == id);
        }

        public List<Deliverer> GetAll()
        {
            return deliverers;
        }
    }
}
