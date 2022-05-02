using DeliveryServiceData.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.UnitOfWork.Implementation
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public InMemoryUnitOfWork()
        {

        }

        public IRepositoryAdditionalService AdditionalService { get; set; } = new InMemoryRepositoryAdditonalService();
        public IRepositoryAdditionalServiceShipment AdditionalServiceShipment { get; set; } = new InMemoryRepositoryAdditonalServiceShipment();
        public IRepositoryShipment Shipment { get; set; } = new InMemoryRepositoryShipment();
        public IRepositoryStatus Status { get; set; } = new InMemoryRepositoryStatus();
        public IRepositoryStatusShipment StatusShipment { get; set; } = new InMemoryRepositoryStatusShipment();
        public IRepositoryShipmentWeight ShipmentWeight { get; set; } = new InMemoryRepositoryShipmentWeight();

        public void Commit()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
