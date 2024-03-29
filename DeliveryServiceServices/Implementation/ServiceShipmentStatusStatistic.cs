﻿using AutoMapper;
using DataTransferObjects;
using DeliveryServiceApp.Services;
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
        private readonly IMapper mapper;

        public ServiceShipmentStatusStatistic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ShipmentStatusStatisticDto FindByID(int id, params int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<ShipmentStatusStatisticDto> GetAll()
        {
            var shipmentStatusStatistics = unitOfWork.ShipmentStatusStatistic.GetAll();
            return mapper.Map<List<ShipmentStatusStatisticDto>>(shipmentStatusStatistics);
        }
    }
}
