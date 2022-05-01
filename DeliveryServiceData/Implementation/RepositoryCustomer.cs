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

        public Customer FindByID(int id, params int[] ids)
        {
            try
            {
                return context.Customers.Find(id);

            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja korisnika! Greška: {ex.Message}");
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom vraćanja svih korisnika! Greška: {ex.Message}");
            }
        }

        public void Edit(Customer entity)
        {
            try
            {
                context.Customers.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom promene podataka korisnika! Greška: {ex.Message}");
            }
        }
    }
}
