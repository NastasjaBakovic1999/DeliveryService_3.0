using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryAdditionalService AdditionalService { get; set; }
        public IRepositoryAdditionalServiceShipment AdditionalServiceShipment { get; set; }
        public IRepositoryShipment Shipment { get; set; }
        public IRepositoryStatus Status { get; set; }
        public IRepositoryStatusShipment StatusShipment { get; set; }
        public IRepositoryShipmentWeight ShipmentWeight { get; set; }
        void Commit();
    }
}
