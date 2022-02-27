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
               .UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = DeliveryServiceDB; ");
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
               new User { PersonId = 1, FirstName = "Pera", LastName = "Peric", Username = "perica", Password = "per1c4", PhoneNumber = "065/111-222-33" },
               new User { PersonId = 2, FirstName = "Zika", LastName = "Zikic", Username = "zikica", Password = "z1k1c4", PhoneNumber = "064/444-555-66" }
            );

            modelBuilder.Entity<Deliverer>().HasData(
                new Deliverer { PersonId = 3, FirstName = "Nastasja", LastName = "Bakovic", Username = "nastasja", Password = "N4st4sj4" },
                new Deliverer { PersonId = 4, FirstName = "Stefan", LastName = "Antic", Username = "stefan", Password = "ant33" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Zakazana" },
                new Status { StatusId = 2, StatusName = "Na pakovanju" },
                new Status { StatusId = 3, StatusName = "Uskladištena za slanje" },
                new Status { StatusId = 4, StatusName = "Kod kurira" },
                new Status { StatusId = 5, StatusName = "U transportu" },
                new Status { StatusId = 6, StatusName = "Uručena" },
                new Status { StatusId = 7, StatusName = "Uskladištena na čekanju" },
                new Status { StatusId = 8, StatusName = "Odbijena" },
                new Status { StatusId = 9, StatusName = "Vraćena pošiljaocu" }
            );

            modelBuilder.Entity<AdditionalService>().HasData(
                new AdditionalService { AdditionalServiceId = 1, AdditionalServiceName = "Potpisana otpremnica", AdditionalServicePrice = 50},
                new AdditionalService { AdditionalServiceId = 2, AdditionalServiceName = "Povratnica", AdditionalServicePrice = 50},
                new AdditionalService { AdditionalServiceId = 3, AdditionalServiceName = "Dodatna ambalaza", AdditionalServicePrice = 60},
                new AdditionalService { AdditionalServiceId = 4, AdditionalServiceName = "Lično uručenje", AdditionalServicePrice = 60},
                new AdditionalService { AdditionalServiceId = 5, AdditionalServiceName = "Osiguranje vrednosti", AdditionalServicePrice = 80},
                new AdditionalService { AdditionalServiceId = 6, AdditionalServiceName = "Email izveštaj", AdditionalServicePrice = 30},
                new AdditionalService { AdditionalServiceId = 7, AdditionalServiceName = "SMS izveštaj", AdditionalServicePrice = 30 },
                new AdditionalService { AdditionalServiceId = 8, AdditionalServiceName = "Uručenje danas za sutra do 12h", AdditionalServicePrice = 90 },
                new AdditionalService { AdditionalServiceId = 9, AdditionalServiceName = "Uručenje danas za sutra do 19h", AdditionalServicePrice = 70 }
            );

            modelBuilder.Entity<ShipmentType>().HasData(
               new ShipmentType { ShipmentTypeId = 1, ShipmentTypeName = "Standardna", ShipmentTypePrice = 220},
               new ShipmentType { ShipmentTypeId = 2, ShipmentTypeName = "Specijalna", ShipmentTypePrice = 350},
               new ShipmentType { ShipmentTypeId = 3, ShipmentTypeName = "Međunarodna", ShipmentTypePrice = 900}
           );


            modelBuilder.Entity<Location>().HasData(
                new Location { LocationId = 1, LocationName = "Beograd"},
                new Location { LocationId = 2, LocationName = "Valjevo" },
                new Location { LocationId = 3, LocationName = "Vranje"},
                new Location { LocationId = 4, LocationName = "Zaječar"},
                new Location { LocationId = 5, LocationName = "Zrenjanin"},
                new Location { LocationId = 6, LocationName = "Jagodina"},
                new Location { LocationId = 7, LocationName = "Kragujevac"},
                new Location { LocationId = 8, LocationName = "Kraljevo"},
                new Location { LocationId = 9, LocationName = "Kruševac"},
                new Location { LocationId = 10, LocationName = "Leskovac"},
                new Location { LocationId = 11, LocationName = "Loznica"},
                new Location { LocationId = 12, LocationName = "Niš"},
                new Location { LocationId = 13, LocationName = "Novi Pazar"},
                new Location { LocationId = 14, LocationName = "Novi Sad"},
                new Location { LocationId = 15, LocationName = "Pančevo"},
                new Location { LocationId = 16, LocationName = "Požarevac"},
                new Location { LocationId = 17, LocationName = "Priština"},
                new Location { LocationId = 18, LocationName = "Smederevo"},
                new Location { LocationId = 19, LocationName = "Sombor"},
                new Location { LocationId = 20, LocationName = "Sremska Mitrovica" },
                new Location { LocationId = 21, LocationName = "Subotica"},
                new Location { LocationId = 22, LocationName = "Užice"},
                new Location { LocationId = 23, LocationName = "Čačak"},
                new Location { LocationId = 24, LocationName = "Šabac"},
                new Location { LocationId = 25, LocationName = "Pirot"}
           );
        }
    }
}
