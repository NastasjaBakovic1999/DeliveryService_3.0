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

        public Deliverer FindByID(int id, params int[] ids)
        {
            try
            {
                return context.Deliverers.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja kurira! Greška: {ex.Message}");
            }
        }

        public List<Deliverer> GetAll()
        {
            try
            {
                return context.Deliverers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom vraćanja svih kurira! Greška: {ex.Message}");
            }
        }
    }
}
