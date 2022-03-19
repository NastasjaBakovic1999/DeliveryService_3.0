using DeliveryServiceData.Implementation;
using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryServiceContext context;

        public UnitOfWork(DeliveryServiceContext context)
        {
            this.context = context;
            Shipment = new RepositoryShipment(context);
            Status = new RepositoryStatus(context);
            StatusShipment = new RepositoryStatusShipment(context);
            AdditionalService = new RepositoryAdditionalService(context);
            AdditionalServiceShipment = new RepositoryAdditionalServiceShipment(context);
            ShipmentWeight = new RepositoryShipmentWeight(context);
        }

        public IRepositoryAdditionalService AdditionalService { get; set; }
        public IRepositoryAdditionalServiceShipment AdditionalServiceShipment { get; set; }
        public IRepositoryShipment Shipment { get; set; }
        public IRepositoryStatus Status { get; set; }
        public IRepositoryStatusShipment StatusShipment { get; set; }
        public IRepositoryShipmentWeight ShipmentWeight { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
