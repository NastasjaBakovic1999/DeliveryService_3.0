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

        public AdditionalService FindByID(int id, params int[] ids)
        {
            try
            {
                return context.AdditionalServices.Find(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error loading additional service! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public List<AdditionalService> GetAll()
        {
            try
            {
              return context.AdditionalServices.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Error returning all additional services! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }
    }
}
