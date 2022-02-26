using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("Persons");

            entity.Property(e => e.PersonId)
                .HasColumnName("PersonId")
                .IsRequired();

            entity.Property(e => e.Username)
                .HasColumnName("Username")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            entity.Property(e => e.Password)
               .HasColumnName("Password")
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(20);

            entity.Property(e => e.FirstName)
               .HasColumnName("FirstName")
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(20);

            entity.Property(e => e.LastName)
              .HasColumnName("LastName")
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(20);
        }
    }
}
