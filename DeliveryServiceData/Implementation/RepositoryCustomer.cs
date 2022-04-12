using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryCustomer : IRepositoryCustomer
    {
        private readonly PersonContext context;

        public RepositoryCustomer(PersonContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            context.Customers.Remove(entity);
        }

        public Customer FindByID(int id, params int[] ids)
        {
            return context.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Edit(Customer entity)
        {
            context.Customers.Update(entity);
        }
    }
}
