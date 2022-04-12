using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryDeliverer : IRepositoryDeliverer
    {
        private readonly PersonContext context;

        public RepositoryDeliverer(PersonContext context)
        {
            this.context = context;
        }

        public void Add(Deliverer entity)
        {
            context.Deliverers.Add(entity);
        }

        public void Delete(Deliverer entity)
        {
            context.Deliverers.Remove(entity);
        }

        public Deliverer FindByID(int id, params int[] ids)
        {
            return context.Deliverers.Find(id);
        }

        public List<Deliverer> GetAll()
        {
            return context.Deliverers.ToList();
        }
    }
}
