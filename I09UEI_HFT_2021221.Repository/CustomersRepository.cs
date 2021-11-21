using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace I09UEI_HFT_2021221.Repository
{
    public class CustomersRepository
    {

        public class CustomersRepository : Repository<Customers>, ICustomers
        {
            public CustomersRepository(DbContext ctx) : base(ctx)
            {
            }

            public override void AddNew(Customers obj)
            {
                this.Ctx.Set<Customers>().Add(obj);
                this.Ctx.SaveChanges();
            }

            public void ChangeName(int id, string newName)
            {
                var cust = this.ListOne(id);
                if (cust == null)
                {
                    throw new InvalidOperationException("There is no such customer.");
                }

                cust.Name = newName;
                this.Ctx.SaveChanges();
            }

            public override void Delete(int id)
            {
                Customers obj = this.ListOne(id);
                this.Ctx.Set<Customers>().Remove(obj);
                this.Ctx.SaveChanges();
            }

            public override Customers ListOne(int id)
            {
                return this.ListAll().SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
