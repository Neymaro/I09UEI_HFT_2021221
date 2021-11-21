using Microsoft.EntityFrameworkCore;
using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace I09UEI_HFT_2021221.Data
{

    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjectDB.mdf;Integrated Security=True


    public class TravelAgencyDbContext
    {
         public TravelAgencyDbContext()
        {
            Database.EnsureCreated();
        }
        
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<TravelAgencies> TravelAgencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder ez)
        {
            if (ez != null && !ez.IsConfigured)
            {
                ez.UseLazyLoadingProxies().UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB; Attachdbfilename=|DataDirectory|\MyDatabase.mdf; Integrated security=True; MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // TRAVEL AGENGY DATA ADD // 
            TravelAgencies tui = new TravelAgencies() { Id = 1, Name = "Tui", PointOfAgency = 5 };
            TravelAgencies thomascook = new TravelAgencies() { Id = 2, Name = "Thomas Cook", PointOfAgency = 4 };
            TravelAgencies expedia = new TravelAgencies() { Id = 3, Name = "Expedia", PointOfAgency = 4 };
            TravelAgencies agoda = new TravelAgencies() { Id = 4, Name = "Agoda", PointOfAgency = 3 };
            TravelAgencies booking = new TravelAgencies() { Id = 5, Name = "Booking", PointOfAgency = 4 };
            TravelAgencies londontown = new TravelAgencies() { Id = 6, Name = "London Town", PointOfAgency = 1 };
            TravelAgencies wizz = new TravelAgencies() { Id = 7, Name = "Wizz Travel", PointOfAgency = 5 };
            // CUSTOMER DATA // 
            Customers customer1 = new Customers() { Id = 1, Name = "Adam Smith", Phone = 36412832, TravelAgencieId = tui.Id };
            Customers customer2 = new Customers() { Id = 2, Name = "Sulumanin Mehmet", Phone = 2352342, TravelAgencieId = agoda.Id };
            Customers customer3 = new Customers() { Id = 3, Name = "Hamza Unsal", Phone = 13534623, TravelAgencieId = booking.Id };
            Customers customer4 = new Customers() { Id = 4, Name = "Hunor Nas", Phone = 1353467213, TravelAgencieId = tui.Id };
            Customers customer5 = new Customers() { Id = 5, Name = "Utku Tekin", Phone = 75733523, TravelAgencieId = expedia.Id };
            Customers customer6 = new Customers() { Id = 6, Name = "Topal Ahmet", Phone = 145282523, TravelAgencieId = thomascook.Id };
            Customers customer7 = new Customers() { Id = 7, Name = "Micheal Jackson", Phone = 885182635, TravelAgencieId = londontown.Id };
            Customers customer8 = new Customers() { Id = 8, Name = "Palinka Jo", Phone = 4378832, TravelAgencieId = wizz.Id };
            Customers customer9 = new Customers() { Id = 9, Name = "Obuda Ricardinho", Phone = 25786214, TravelAgencieId = thomascook.Id };


            // Packages Cat =  [ Health , Winter , Summer , Cultural ]

            Packages package1 = new Packages() { Id = 1, Name = "All Inclusive Turkey", Category = "Summer", Price = 3420,VisaNeeded = false, TravelAgencieId= thomascook.Id };
            Packages package2 = new Packages() { Id = 2, Name = "All Inclusive Egypt", Category = "Summer", Price = 6531, VisaNeeded = false, TravelAgencieId= expedia.Id };
            Packages package3 = new Packages() { Id = 3, Name = "Breakfast Included Spain", Category = "Summer", Price = 1500, VisaNeeded = true, TravelAgencieId= londontown.Id };
            Packages package4 = new Packages() { Id = 4, Name = "Cultural Balkan", Category = "Cultural", Price = 1210, VisaNeeded = false, TravelAgencieId= booking.Id };
            Packages package5 = new Packages() { Id = 5, Name = "Cold Winter", Category = "Winter/Ski", Price = 3330, VisaNeeded = true, TravelAgencieId= tui.Id };
            Packages package6 = new Packages() { Id = 6, Name = "Hot Sea Tour", Category = "Health", Price = 1200, VisaNeeded = true, TravelAgencieId= wizz.Id };
            Packages package7 = new Packages() { Id = 7, Name = "Healthy Water Tour", Category = "Health", Price = 1234, VisaNeeded = false, TravelAgencieId= agoda.Id };
            Packages package8 = new Packages() { Id = 8, Name = "Cold As It Is Tour", Category = "Winter", Price = 2500, VisaNeeded = true, TravelAgencieId= wizz.Id };



            // connections
            modelBuilder.Entity<Packages>(entity =>
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

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property( x => x.Id)
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

            modelBuilder.Entity<TravelAgencies>(entity =>
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


            // Model-Data Adding
            modelBuilder.Entity<Customers>().HasData(customer1, customer2, customer3, customer4, customer5, customer6, customer7, customer8,customer9);
            modelBuilder.Entity<TravelAgencies>().HasData(tui, thomascook, booking, agoda, wizz,londontown, expedia);
            modelBuilder.Entity<Packages>().HasData(package1, package2, package3, package4, package5, package6, package7, package8);
        }
    }
    }
}
