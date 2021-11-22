using System;
using System.Collections.Generic;
using System.Linq;
using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Repository
{
   public class PackagesRepository : Repository<Packages>, IPackages
    {
        public PackagesRepository(DbContext context) : base(context)
        {
        }

        public override void AddOne(Packages obj)
        {
            this.context.Set<Packages>().Add(obj);
            this.context.SaveChanges();
        }

        public void ChangeCategory(int id, string newCategory)
        {
            var package = this.ListOne(id);
            if (package == null)
            {
                throw new InvalidOperationException("package was not found!");
            }

            package.Category = newCategory;
            this.context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var package = this.ListOne(id);
            if (package == null)
            {
                throw new InvalidOperationException("package was not found!");
            }

            package.Name = newName;
            this.context.SaveChanges();
        }

        public void ChangePrice(int id, int newPrice)
        {
            var package = this.ListOne(id);
            if (package == null)
            {
                throw new InvalidOperationException("package was not found!");
            }

            package.Price = newPrice;
            this.context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Packages obj = this.ListOne(id);
            this.context.Set<Packages>().Remove(obj);
            this.context.SaveChanges();
        }

        public override Packages ListOne(int id)
        {
            return this.ListAll().SingleOrDefault(x => x.Id == id);
        }

        public void VisaNeeded(int id, bool hasSTD)
        {
            var package = this.ListOne(id);
            if (package == null)
            {
                throw new InvalidOperationException("Package could not found!");
            }

            package.VisaNeeded = hasVisa;
            this.context.SaveChanges();
        }
    }
}
}
