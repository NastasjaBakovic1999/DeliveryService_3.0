using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        public IRepositoryAdditionalService AdditionalService { get; set; }
        public IRepositoryAdditionalServiceShipment AdditionalServiceShipment { get; set; }
        public IRepositoryLocation Location { get; set; }
        public IRepositoryShipment Shipment { get; set; }
        public IRepositoryShipmentType ShipmentType { get; set; }
        public IRepositoryStatus Status { get; set; }
        public IRepositoryStatusShipment StatusShipment { get; set; }
        public IRepositoryUser User { get; set; }
        public IRepositoryDeliverer Deliverer { get; set; }
        void Commit();
    }
}
