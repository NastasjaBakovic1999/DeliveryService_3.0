using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class AdditionalServiceConfiguration : IEntityTypeConfiguration<AdditionalService>
    {
        public void Configure(EntityTypeBuilder<AdditionalService> entity)
        {
            entity.ToTable("AdditionalService");

            entity.Property(e => e.AdditionalServiceId)
                .HasColumnName("AdditionalServiceId")
                .IsRequired();

            entity.Property(e => e.AdditionalServiceName)
                .HasColumnName("AdditionalServiceName")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            entity.Property(e => e.AdditionalServicePrice)
                .HasColumnName("AdditionalServicePrice")
                .IsRequired()
                .HasColumnType("float");
        }
    }
}
