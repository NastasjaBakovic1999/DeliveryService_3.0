using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class StatusShipmentConfiguration : IEntityTypeConfiguration<StatusShipment>
    {
        public void Configure(EntityTypeBuilder<StatusShipment> entity)
        {
            entity.ToTable("StatusShipments");

            entity.Property(e => e.StatusId)
                .HasColumnName("StatusId")
                .IsRequired();

            entity.Property(e => e.ShipmentId)
                .HasColumnName("ShipmentId")
                .IsRequired();

            entity.Property(e => e.StatusTime)
                .HasColumnName("StatusTime")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("(getdate())");
        }
    }
}
