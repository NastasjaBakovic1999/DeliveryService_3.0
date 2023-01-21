using DataTransferObjects;
using DeliveryServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceServices.Interfaces
{
    public interface IServiceTimeline : IService<TimelineDto>
    {
        public List<TimelineDto> GetAllFromProcedure(int shipmentId);
    }
}
