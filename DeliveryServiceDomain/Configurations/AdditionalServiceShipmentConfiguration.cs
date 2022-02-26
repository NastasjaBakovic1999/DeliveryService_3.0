using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class AdditionalServiceShipmentConfiguration : IEntityTypeConfiguration<AdditionalServiceShipment>
    {
        public void Configure(EntityTypeBuilder<AdditionalServiceShipment> entity)
        {
            entity.ToTable("AdditionalServiceShipments");

            entity.Property(e => e.AdditionalServiceId)
                .HasColumnName("AdditionalServiceId")
                .IsRequired();

            entity.Property(e => e.ShipmentId)
                .HasColumnName("ShipmentId")
                .IsRequired();
        }
    }
}
