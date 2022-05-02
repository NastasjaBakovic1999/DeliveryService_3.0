using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryStatusShipment : IRepositoryStatusShipment
    {
        private readonly DeliveryServiceContext context;

        public RepositoryStatusShipment(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(StatusShipment statusShipment)
        {
            try
            {
                context.StatusShipments.Add(statusShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving new shipment status! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public void Delete(StatusShipment statusShipment)
        {
            try
            {
                context.StatusShipments.Remove(statusShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting shipment status! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public StatusShipment FindByID(int id, params int[] ids)
        {
            try
            {
                return context.StatusShipments.Find(id, ids[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading shipment and its status! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public List<StatusShipment> GetAll()
        {
            try
            {
                return context.StatusShipments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading all shipments with their statuses! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public void Edit(StatusShipment statusShipment)
        {
            try
            {
                context.StatusShipments.Update(statusShipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error modifying shipment data and its status! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }

        public List<StatusShipment> GetAllByShipmentId(int shipmentId)
        {
            try
            {
                return context.StatusShipments.Where(ss => ss.ShipmentId == shipmentId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading shipment and its status based on shipment id! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }
    }
}