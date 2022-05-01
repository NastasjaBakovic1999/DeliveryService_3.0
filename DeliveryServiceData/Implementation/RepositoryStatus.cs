using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryStatus : IRepositoryStatus
    {
        private readonly DeliveryServiceContext context;

        public RepositoryStatus(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public Status FindByID(int id, params int[] ids)
        {
            try
            {
                return context.Statuses.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja statusa! Greška: {ex.Message}");
            }
        }

        public List<Status> GetAll()
        {
            try
            {
                return context.Statuses.ToList();  
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom vraćanja svih statusa! Greška: {ex.Message}");
            }
        }

        public Status GetByName(string name)
        {
            try
            {
                return context.Statuses.Single(s => s.StatusName == name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja statusa sa zadatim imenom! Greška: {ex.Message}");
            }
        }
    }
}
