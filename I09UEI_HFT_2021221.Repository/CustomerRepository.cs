using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace I09UEI_HFT_2021221.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public override void Insert(Customer obj)
        {
            Context.Set<Customer>().Add(obj);
            Context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var customer = Get(id);
            if (customer is null)
                throw new InvalidOperationException("Customer was not found!");

            customer.Name = newName;
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Customer obj = Get(id);
            Context.Set<Customer>().Remove(obj);
            Context.SaveChanges();
        }

        public override Customer Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
