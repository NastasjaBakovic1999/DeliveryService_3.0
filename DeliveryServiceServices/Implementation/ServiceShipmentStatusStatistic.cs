using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using DeliveryServiceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceServices.Implementation
{
    public class ServiceShipmentStatusStatistic : IServiceShipmentStatusStatistic
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceShipmentStatusStatistic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ShipmentStatusStatistic FindByID(int id, params int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<ShipmentStatusStatistic> GetAll()
        {
            return unitOfWork.ShipmentStatusStatistic.GetAll();
        }
    }
}
