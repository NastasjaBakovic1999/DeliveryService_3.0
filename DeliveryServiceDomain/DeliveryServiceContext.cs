using DeliveryServiceDomain.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class DeliveryServiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }
        public DbSet<AdditionalServiceShipment> AdditionalServiceShipments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ShipmentType> ShipmentTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusShipment> StatusShipments { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }
        public DbSet<Person> Persons { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseLoggerFactory(MyLoggerFactory)
               .EnableSensitiveDataLogging()
               .UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = DeliveryServiceDatabase; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany<Shipment>(l => l.SendingShipments)
                .WithOne(s => s.SendingLocation)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasMany<Shipment>(l => l.ReceivingShipments)
                .WithOne(s => s.ReceivingLocation)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany<Shipment>(u => u.Shipments)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deliverer>()
               .HasMany<Shipment>(d => d.Shipments)
               .WithOne(s => s.Deliverer)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShipmentType>()
                .HasMany<Shipment>(st => st.Shipments)
                .WithOne(s => s.ShipmentType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StatusShipment>(ss =>
            {
                ss.HasKey(ss => new { ss.StatusId, ss.ShipmentId });
                ss.HasOne(a => a.Shipment)
                  .WithMany(b => b.ShipmentStatuses)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdditionalServiceShipment>(ass =>
            {
                ass.HasKey(ass => new { ass.AdditionalServiceId, ass.ShipmentId });
                ass.HasOne(a => a.Shipment)
                   .WithMany(b => b.AdditionalServices)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.ApplyConfiguration(new ShipmentConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new StatusShipmentConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionalServiceConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionalServiceShipmentConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new DelivererConfiguration());
 
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User { PersonId = 1, FirstName = "Pera", LastName = "Peric", Username = "perica", Password = "per1c4" },
               new User { PersonId = 2, FirstName = "Zika", LastName = "Zikic", Username = "zikica", Password = "z1k1c4" }
            );

            modelBuilder.Entity<Deliverer>().HasData(
                new Deliverer { PersonId = 1, FirstName = "Nastasja", LastName = "Bakovic", Username = "nastasja", Password = "N4st4sj4" },
                new Deliverer { PersonId = 2, FirstName = "Stefan", LastName = "Antic", Username = "stefan", Password = "ant33" }
            );
        }
    }
}
