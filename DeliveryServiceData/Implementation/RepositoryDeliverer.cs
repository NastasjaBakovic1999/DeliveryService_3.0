using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryDeliverer : IRepositoryDeliverer
    {
        private readonly DeliveryServiceContext context;

        public RepositoryDeliverer(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(Deliverer deliverer)
        {
            context.Deliverers.Add(deliverer);
        }

        public void Delete(Deliverer deliverer)
        {
            context.Deliverers.Remove(deliverer);
        }

        public Deliverer FindByID(int id, params int[] ids)
        {
            return context.Deliverers.Find(id);
        }

        public List<Deliverer> GetAll()
        {
            return context.Deliverers.ToList();
        }

        public Deliverer GetByUsernameAndPassword(Deliverer deliverer)
        {
            return context.Deliverers.Single(d=> d.Username == deliverer.Username && d.Password == deliverer.Password);
        }

        public Deliverer Search(Expression<Func<Deliverer, bool>> pred)
        {
            return context.Deliverers.Single(pred);
        }
    }
}
