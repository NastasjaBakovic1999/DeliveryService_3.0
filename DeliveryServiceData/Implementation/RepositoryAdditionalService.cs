using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryAdditionalService : IRepositoryAdditionalService
    {
        private readonly DeliveryServiceContext context;

        public RepositoryAdditionalService(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(AdditionalService additionalService)
        {
            context.AdditionalServices.Add(additionalService);
        }

        public void Delete(AdditionalService additionalService)
        {
            context.AdditionalServices.Remove(additionalService);
        }

        public AdditionalService FindByID(int id, params int[] ids)
        {
            return context.AdditionalServices.Find(id);
        }

        public List<AdditionalService> GetAll()
        {
            return context.AdditionalServices.ToList();
        }
    }
}
