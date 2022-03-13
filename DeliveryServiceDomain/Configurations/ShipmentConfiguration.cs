using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain.Configurations
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> entity)
        {
            entity.ToTable("Shipments");

            entity.Property(e => e.ShipmentId)
                .HasColumnName("ShipmentId")
                .IsRequired();

            entity.Property(e => e.ShipmentCode)
                .HasColumnName("ShipmentCode")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(12);

            entity.Property(e => e.ShipmentWeight)
                .HasColumnName("ShipmentWeight")
                .IsRequired()
                .HasColumnType("float");

            entity.Property(e => e.ShipmentContent)
                .HasColumnName("ShipmentContent")
                .HasColumnType("varchar")
                .HasMaxLength(30);

            entity.Property(e => e.ShipmentTypeId)
                .HasColumnName("ShipmentTypeId")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.SendingLocationId)
                .HasColumnName("SendingLocationId")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.ReceivingLocationId)
                .HasColumnName("ReceivingLocationId")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.ContactPersonName)
                .HasColumnName("ContactPersonName")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.ContactPersonPhone)
                .HasColumnName("ContactPersonPhone")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(e => e.Street)
                .HasColumnName("Street")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            entity.Property(e => e.PostalNo)
                .HasColumnName("PostalNo")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(5);

            entity.Property(e => e.CustomerId)
                .HasColumnName("UserId")
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValueSql("(CONVERT([int],session_context(N'PersonId')))");

            entity.Property(e => e.DelivererId)
                .HasColumnName("DelivererId")
                .HasColumnType("int")
                .HasDefaultValueSql("(CONVERT([int],session_context(N'PersonId')))");

            entity.Property(e => e.Price)
                .HasColumnName("Price")
                .IsRequired()
                .HasColumnType("float");

            entity.Property(e => e.Note)
                .HasColumnName("Note")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}
