using AutoMapper;
using DataTransferObjects;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceServices.Implementation
{
    public class ServiceTimeline : IServiceTimeline
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServiceTimeline(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public TimelineDto FindByID(int id, params int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<TimelineDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<TimelineDto> GetAllFromProcedure(int shipmentId)
        {
            var statusTimeline = unitOfWork.Timeline.GetAllFromProcedure(shipmentId);
            return mapper.Map<List<TimelineDto>>(statusTimeline);
        }
    }
}
