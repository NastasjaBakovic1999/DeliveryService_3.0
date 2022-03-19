using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class ShipmentWeightConfiguration : IEntityTypeConfiguration<ShipmentWeight>
    {
        public void Configure(EntityTypeBuilder<ShipmentWeight> entity)
        {
            entity.ToTable("ShipmentWeight");

            entity.Property(e => e.ShipmentWeightId)
                .HasColumnName("ShipmentWeightId")
                .IsRequired();

            entity.Property(e => e.ShipmentWeightDescpription)
                .HasColumnName("Desc")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(40);

            entity.Property(e => e.ShipmentWeightPrice)
                .HasColumnName("ShipmentWeightPrice")
                .IsRequired()
                .HasColumnType("float");
        }
    }
}
