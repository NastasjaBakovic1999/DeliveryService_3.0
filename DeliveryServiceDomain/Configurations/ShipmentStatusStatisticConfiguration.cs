using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class ShipmentStatusStatisticConfiguration :  IEntityTypeConfiguration<ShipmentStatusStatistic>
    { 
        public void Configure(EntityTypeBuilder<ShipmentStatusStatistic> entity)
        {
            entity.HasNoKey();
            entity.ToView(nameof(ShipmentStatusStatistic));
            entity.Property(e => e.StatusName).HasColumnName("StatusName");
            entity.Property(e => e.NumberOfShipments).HasColumnName("NumberOfShipments");
        }
    }
}
