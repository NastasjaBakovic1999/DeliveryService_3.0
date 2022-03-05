using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasBaseType<Person>().ToTable("Users");

            entity.Property(e => e.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            entity.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }

    }
}
