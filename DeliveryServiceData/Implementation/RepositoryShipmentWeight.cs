using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    internal class RepositoryShipmentWeight : IRepositoryShipmentWeight
    {
        private readonly DeliveryServiceContext context;

        public RepositoryShipmentWeight(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public ShipmentWeight FindByID(int id, params int[] ids)
        {
            try
            {
                return context.ShipmentWeights.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading shipment weight! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public List<ShipmentWeight> GetAll()
        {
            try
            {
                return context.ShipmentWeights.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading all shipment weights! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }
    }
}
