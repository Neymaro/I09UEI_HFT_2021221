using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace I09UEI_HFT_2021221.Data
{

    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjectDB.mdf;Integrated Security=True


    public class TravelAgencyDbContext : DbContext
    {
        public TravelAgencyDbContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<TravelAgency> TravelAgencies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieAppDb.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TravelAgency tui = new() { Id = 1, Name = "Tui", PointOfAgency = 5 };
            TravelAgency thomascook = new() { Id = 2, Name = "Thomas Cook", PointOfAgency = 4 };
            TravelAgency expedia = new() { Id = 3, Name = "Expedia", PointOfAgency = 4 };
            TravelAgency agoda = new() { Id = 4, Name = "Agoda", PointOfAgency = 3 };
            TravelAgency booking = new() { Id = 5, Name = "Booking", PointOfAgency = 4 };
            TravelAgency londontown = new() { Id = 6, Name = "London Town", PointOfAgency = 1 };
            TravelAgency wizz = new() { Id = 7, Name = "Wizz Travel", PointOfAgency = 5 };

            var customers = new List<Customer>() {
                new() { Id = 1, Name = "Adam Smith", Phone = 36412832, TravelAgencieId = tui.Id },
                new() { Id = 2, Name = "Sulumanin Mehmet", Phone = 2352342, TravelAgencieId = agoda.Id },
                new() { Id = 3, Name = "Hamza Unsal", Phone = 13534623, TravelAgencieId = booking.Id },
                new() { Id = 4, Name = "Hunor Nas", Phone = 1353467213, TravelAgencieId = tui.Id },
                new() { Id = 5, Name = "Utku Tekin", Phone = 75733523, TravelAgencieId = expedia.Id },
                new() { Id = 6, Name = "Topal Ahmet", Phone = 145282523, TravelAgencieId = thomascook.Id },
                new() { Id = 7, Name = "Micheal Jackson", Phone = 885182635, TravelAgencieId = londontown.Id },
                new() { Id = 8, Name = "Palinka Jo", Phone = 4378832, TravelAgencieId = wizz.Id },
                new() { Id = 9, Name = "Obuda Ricardinho", Phone = 25786214, TravelAgencieId = thomascook.Id }
            };

            var packages = new List<Package>() {
                new() { Id = 1, Name = "All Inclusive Turkey", Category = "Summer", Price = 3420, VisaNeeded = false, TravelAgencieId = thomascook.Id },
                new() { Id = 2, Name = "All Inclusive Egypt", Category = "Summer", Price = 6531, VisaNeeded = false, TravelAgencieId = expedia.Id },
                new() { Id = 3, Name = "Breakfast Included Spain", Category = "Summer", Price = 1500, VisaNeeded = true, TravelAgencieId = londontown.Id },
                new() { Id = 4, Name = "Cultural Balkan", Category = "Cultural", Price = 1210, VisaNeeded = false, TravelAgencieId = booking.Id },
                new() { Id = 5, Name = "Cold Winter", Category = "Winter/Ski", Price = 3330, VisaNeeded = true, TravelAgencieId = tui.Id },
                new() { Id = 6, Name = "Hot Sea Tour", Category = "Health", Price = 1200, VisaNeeded = true, TravelAgencieId = wizz.Id },
                new() { Id = 7, Name = "Healthy Water Tour", Category = "Health", Price = 1234, VisaNeeded = false, TravelAgencieId = agoda.Id },
                new() { Id = 8, Name = "Cold As It Is Tour", Category = "Winter", Price = 2500, VisaNeeded = true, TravelAgencieId = wizz.Id }
            };

            ConfigurePackages(modelBuilder);

            ConfigureCustomers(modelBuilder);

            ConfigureTravelAgencies(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<TravelAgency>().HasData(tui, thomascook, booking, agoda, wizz, londontown, expedia);
            modelBuilder.Entity<Package>().HasData(packages);
        }

        private static void ConfigurePackages(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasOne(package => package.TravelAgencie)
                     .WithMany(agency => agency.Packages)
                     .HasForeignKey(package => package.TravelAgencieId)
                     .OnDelete(DeleteBehavior.SetNull);

                entity.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

                entity.Property(x => x.Name)
                    .HasMaxLength(80)
                    .IsRequired();

                entity.Property(x => x.Category)
                   .HasMaxLength(115)
                   .IsRequired();

                entity.Property(x => x.Price)
                   .HasMaxLength(6)
                   .IsRequired();

                entity.Property(x => x.Description)
                   .HasMaxLength(110)
                   .IsRequired();

            });
        }

        private static void ConfigureCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

                entity.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

                entity.Property(x => x.Phone)
                   .HasMaxLength(20)
                   .IsRequired();

                entity.HasOne(cstmr => cstmr.TravelAgencie)
                     .WithMany(agency => agency.Customers)
                     .HasForeignKey(package => package.TravelAgencieId)
                     .OnDelete(DeleteBehavior.SetNull);

            });
        }

        private static void ConfigureTravelAgencies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelAgency>(entity =>
            {
                entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

                entity.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

                entity.Property(x => x.Packages)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(x => x.PointOfAgency)
                .HasMaxLength(1)
                .IsRequired();

            });
        }
    }
}