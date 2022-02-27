using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.ToTable("Statuses");

            entity.Property(e => e.StatusId)
                .HasColumnName("StatusId")
                .IsRequired();

            entity.Property(e => e.StatusName)
                .HasColumnName("StatusName")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(40);
        }
    }
}
