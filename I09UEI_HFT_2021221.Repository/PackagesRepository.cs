using System;
using System.Linq;
using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace I09UEI_HFT_2021221.Repository
{
    public class PackagesRepository : Repository<Packages>, IPackages
    {
        public PackagesRepository(DbContext context) : base(context) { }

        public override void Insert(Packages obj)
        {
            Context.Set<Packages>().Add(obj);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Packages obj = Get(id);
            Context.Set<Packages>().Remove(obj);
            Context.SaveChanges();
        }

        public override Packages Get(int id) => GetAll().SingleOrDefault(x => x.Id == id);

        public void ChangeName(int id, string newName)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("package was not found!");

            package.Name = newName;
            Context.SaveChanges();
        }

        public void ChangeCategory(int id, string newCategory)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("package was not found!");

            package.Category = newCategory;
            Context.SaveChanges();
        }


        public void ChangePrice(int id, int newPrice)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("package was not found!");

            package.Price = newPrice;
            Context.SaveChanges();
        }

        public void VisaNeeded(int id, bool hasVisa)
        {
            var package = Get(id);
            if (package is null)
                throw new InvalidOperationException("Package could not found!");

            package.VisaNeeded = hasVisa;
            Context.SaveChanges();
        }
    }
}
