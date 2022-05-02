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
        public IRepositoryAdditionalServiceShipment AdditionalServiceShipment { get; set; }
        public IRepositoryShipment Shipment { get; set; }
        public IRepositoryStatus Status { get; set; }
        public IRepositoryStatusShipment StatusShipment { get; set; }
        public IRepositoryShipmentWeight ShipmentWeight { get; set; }

        public void Commit()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
