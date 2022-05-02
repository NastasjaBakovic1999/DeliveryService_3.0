using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryAdditionalServiceShipment : IRepositoryAdditionalServiceShipment
    {
        private readonly DeliveryServiceContext context;

        public RepositoryAdditionalServiceShipment(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(AdditionalServiceShipment additionalServiceShipment)
        {
            try
            {
                context.AdditionalServiceShipments.Add(additionalServiceShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving shipment and its additional services! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public void Delete(AdditionalServiceShipment additionalServiceShipment)
        {
            try
            {
                context.AdditionalServiceShipments.Remove(additionalServiceShipment);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error deleting shipment and its additional service! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public AdditionalServiceShipment FindByID(int id, params int[] ids)
        {
            try
            {
                return context.AdditionalServiceShipments.Find(id, ids[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading shipment and its additional service! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public List<AdditionalServiceShipment> GetAll()
        {
            try
            {
               return context.AdditionalServiceShipments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error returning all shipments and their additional services! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public void Edit(AdditionalServiceShipment additionalServiceShipment)
        {
            try
            {
                context.AdditionalServiceShipments.Update(additionalServiceShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error changing shipment data and its additional services! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public List<AdditionalServiceShipment> GetByShipmentId(int shipmentId)
        {
            try
            {
                 return context.AdditionalServiceShipments.Where(ass => ass.ShipmentId == shipmentId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading shipments and their additional services based on shipment id! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public List<AdditionalServiceShipment> Search(Expression<Func<AdditionalServiceShipment, bool>> pred)
        {
            try
            {
               return context.AdditionalServiceShipments.Where(pred).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching for shipments and their additional services! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }
    }
}
