using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.ToTable("Locations");

            entity.Property(e => e.LocationId)
                .HasColumnName("LocationId")
                .IsRequired();

            entity.Property(e => e.LocationName)
                .HasColumnName("LocationName")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(25);
        }
    }
}
