using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Repository
{
    public class CustomersRepository : Repository<Customers>, ICustomers
    {
        public CustomersRepository(DbContext context) : base(context)
        {
        }

        public override void AddOne(Customers obj)
        {
            this.Ctx.Set<Customers>().Add(obj);
            this.context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var customer = this.ListOne(id);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer was not found!");
            }

            customer.Name = newName;
            this.context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Customers obj = this.ListOne(id);
            this.context.Set<Customers>().Remove(obj);
            this.context.SaveChanges();
        }

        public override Customers ListOne(int id)
        {
            return this.ListAll()
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
