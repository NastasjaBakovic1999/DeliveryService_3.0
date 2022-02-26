using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class ShipmentTypeConfiguration : IEntityTypeConfiguration<ShipmentType>
    {
        public void Configure(EntityTypeBuilder<ShipmentType> entity)
        {
            entity.ToTable("ShipmentTypes");

            entity.Property(e => e.ShipmentTypeId)
                .HasColumnName("ShipmentTypeId")
                .IsRequired();

            entity.Property(e => e.ShipmentTypeName)
                .HasColumnName("ShipmentTypeName")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            entity.Property(e => e.ShipmentTypePrice)
                .HasColumnName("ShipmentTypePrice")
                .IsRequired()
                .HasColumnType("float");
        }
    }
}
