using System;
using System.Linq;
using I09UEI_HFT_2021221.Data;
using I09UEI_HFT_2021221.Models;

namespace I09UEI_HFT_2021221.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        private readonly TravelAgencyDbContext _context;

        public PackageRepository(TravelAgencyDbContext context) : base(context)
        {
            _context = context;
        }

        public override void Insert(Package obj)
        {
            _context.Set<Package>().Add(obj);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Package obj = Get(id);
            _context.Set<Package>().Remove(obj);
            _context.SaveChanges();
        }

        public override Package Get(int id) => GetAll().SingleOrDefault(x => x.Id == id);

        public void ChangeName(int id, string newName)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("package was not found!");

            package.Name = newName;
            _context.SaveChanges();
        }

        public void ChangeCategory(int id, string newCategory)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("package was not found!");

            package.Category = newCategory;
            _context.SaveChanges();
        }


        public void ChangePrice(int id, int newPrice)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("package was not found!");

            package.Price = newPrice;
            _context.SaveChanges();
        }

        public void VisaNeeded(int id, bool hasVisa)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("Package could not found!");

            package.VisaNeeded = hasVisa;
            _context.SaveChanges();
        }
    }
}
