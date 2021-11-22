using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace I09UEI_HFT_2021221.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly DbContext _context;

        public CustomerRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public override void Insert(Customer obj)
        {
            _context.Set<Customer>().Add(obj);
            _context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var customer = Get(id);
            if (customer is null)
                throw new InvalidOperationException("Customer was not found!");

            customer.Name = newName;
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Customer obj = Get(id);
            _context.Set<Customer>().Remove(obj);
            _context.SaveChanges();
        }

        public override Customer Get(int id) => GetAll().SingleOrDefault(x => x.Id == id);

        public void ChangeCustomerPhone(int id, int phoneNumber)
        {
            Customer customer = Get(id);
            if (customer is null)
                throw new InvalidOperationException("Customer was not found!");

            customer.Phone = phoneNumber;
            _context.SaveChanges();
        }
    }
}
