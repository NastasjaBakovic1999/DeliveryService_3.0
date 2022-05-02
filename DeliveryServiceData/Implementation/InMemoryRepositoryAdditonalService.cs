using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryAdditonalService : IRepositoryAdditionalService
    {
        private List<AdditionalService> additionalServices = new List<AdditionalService>();


        public AdditionalService FindByID(int id, params int[] ids)
        {
            return additionalServices.Find(ads => ads.AdditionalServiceId == id);
        }

        public List<AdditionalService> GetAll()
        {
            return additionalServices;
        }
    }
}
