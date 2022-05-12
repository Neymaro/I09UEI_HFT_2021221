using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace I09UEI_HFT_2021221.Data
{
    public class TravelAgencyDbContext : DbContext
    {
        public const int NameMaxLength = 80;
        public const int PhoneNumMaxLength = 20;
//        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjectDb.mdf;Integrated Security=True";
        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=PROJECTDb;Integrated Security=True";
        
        //public const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testdb123;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //public const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=ProjectDb;Trusted_Connection=True";

        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            // Dear Teacher if this error appear, I have no idea what exactly it is but please try to change DB with localhost\SQLEXPRESS . 
            // I have checked everywhere but none of information says my issue :/
            // It works anyway with SqlExpress
        }
        public TravelAgencyDbContext()
        {
            Database.EnsureCreated();
        }
        
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<TravelAgency> TravelAgencies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TravelAgency tui = new() { Id = 1, Name = "Tui", Rating = 5 };
            TravelAgency thomascook = new() { Id = 2, Name = "Thomas Cook", Rating = 4 };
            TravelAgency expedia = new() { Id = 3, Name = "Expedia", Rating = 4 };
            TravelAgency agoda = new() { Id = 4, Name = "Agoda", Rating = 3 };
            TravelAgency booking = new() { Id = 5, Name = "Booking", Rating = 4 };
            TravelAgency londontown = new() { Id = 6, Name = "London Town", Rating = 1 };
            TravelAgency wizz = new() { Id = 7, Name = "Wizz Travel", Rating = 5 };

            var customers = new List<Customer>() {
                new() { Id = 1, Name = "Adam Smith",        Phone = 36412832, TravelAgencyId = tui.Id },
                new() { Id = 2, Name = "Hunor Nas",  Phone = 2352342, TravelAgencyId = agoda.Id },
                new() { Id = 3, Name = "Utku Kahramanturk",       Phone = 13534623, TravelAgencyId = booking.Id },
                new() { Id = 4, Name = "Hamza Unsal",         Phone = 1353467213, TravelAgencyId = tui.Id },
                new() { Id = 5, Name = "Utku Tekin",        Phone = 75733523, TravelAgencyId = expedia.Id },
                new() { Id = 6, Name = "Guven Baba",       Phone = 145282523, TravelAgencyId = thomascook.Id },
                new() { Id = 7, Name = "Micheal Jackson",   Phone = 885182635, TravelAgencyId = londontown.Id },
                new() { Id = 8, Name = "Palinka Jo",        Phone = 4378832, TravelAgencyId = wizz.Id },
                new() { Id = 9, Name = "Obuda Ricardinho",  Phone = 2578614, TravelAgencyId = agoda.Id }
            };

            var packages = new List<Package>() {
                new() { Id = 1, Name = "All Inclusive Turkey",  Description= "Desc", Category = "Summer", Price = 3420, VisaNeeded = false, TravelAgencyId = thomascook.Id },
                new() { Id = 2, Name = "All Inclusive Egypt",   Description= "Desc", Category = "Summer", Price = 6531, VisaNeeded = false, TravelAgencyId = expedia.Id },
                new() { Id = 3, Name = "Breakfast Included Spain", Description= "Desc", Category = "Summer", Price = 1500, VisaNeeded = true, TravelAgencyId = londontown.Id },
                new() { Id = 4, Name = "Cultural Balkan",       Description= "Desc", Category = "Cultural", Price = 1210, VisaNeeded = false, TravelAgencyId = booking.Id },
                new() { Id = 5, Name = "Cold Winter",           Description= "Desc", Category = "Winter/Ski", Price = 3330, VisaNeeded = true, TravelAgencyId = tui.Id },
                new() { Id = 6, Name = "Hot Sea Tour",          Description= "Desc", Category = "Health", Price = 1200, VisaNeeded = true, TravelAgencyId = wizz.Id },
                new() { Id = 7, Name = "Healthy Water Tour",    Description= "Desc", Category = "Health", Price = 1234, VisaNeeded = false, TravelAgencyId = agoda.Id },
                new() { Id = 8, Name = "Cold As It Is Tour",    Description= "Desc", Category = "Winter", Price = 2500, VisaNeeded = false, TravelAgencyId = wizz.Id }
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
                entity.ToTable("packages");

                entity.HasOne(package => package.TravelAgency)
                    .WithMany(agency => agency.Packages)
                    .HasForeignKey(package => package.TravelAgencyId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                entity.Property(x => x.Name)
                    .HasMaxLength(NameMaxLength)
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
                entity.ToTable("customers");

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                entity.Property(x => x.Name)
                    .HasMaxLength(NameMaxLength)
                    .IsRequired();

                entity.Property(x => x.Phone)
                    .HasMaxLength(PhoneNumMaxLength)
                    .IsRequired();

                entity.HasOne(cstmr => cstmr.TravelAgency)
                    .WithMany(agency => agency.Customers)
                    .HasForeignKey(package => package.TravelAgencyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
        private static void ConfigureTravelAgencies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelAgency>(entity =>
            {
                entity.ToTable("travelAgencies");

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                entity.Property(x => x.Name)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(x => x.Rating)
                    .HasMaxLength(1)
                    .IsRequired();
            });
        }
    }
}