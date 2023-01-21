using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class TimelineConfiguration : IEntityTypeConfiguration<Timeline>
    {
        public void Configure(EntityTypeBuilder<Timeline> entity)
        {
            entity.HasNoKey();
            entity.Property(e => e.StatusName).HasColumnName("StatusName");
            entity.Property(e => e.StatusTime).HasColumnName("StatusTime");
        }
    }
}
