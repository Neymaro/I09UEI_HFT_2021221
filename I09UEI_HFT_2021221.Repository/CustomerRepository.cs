using I09UEI_HFT_2021221.Data;
using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace I09UEI_HFT_2021221.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly TravelAgencyDbContext _context;

        public CustomerRepository(TravelAgencyDbContext context) : base(context)
        {
            _context = context;
        }

        public override void Insert(Customer obj)
        {
            _context.Set<Customer>().Add(obj);
            _context.SaveChanges();
        }

        public Customer Update(int id, string name, int phoneNumber)
        {
            var customer = Get(id);
            if (customer is null)
                return null;

            customer.Name = name;
            customer.Phone = phoneNumber;

            _context.SaveChanges();

            return customer;
        }

        public override void Delete(int id)
        {
            Customer obj = Get(id);
            _context.Set<Customer>().Remove(obj);
            _context.SaveChanges();
        }
        //.Include(x => x.TravelAgency)
        public override Customer Get(int id) => GetAll().SingleOrDefault(x => x.Id == id);

        public void ChangeCustomerPhone(int id, int phoneNumber)
        {
            Customer customer = Get(id);
            if (customer is null)
                throw new InvalidOperationException("Customer was not found!");

            customer.Phone = phoneNumber;
            _context.SaveChanges();
        }

        public IList<Customer> GetCustomersOfTravelAgency(string travelAgencyName)
        {
            var customerList = _context.Customers
                .Include(x=>x.TravelAgency)
                .Where(x=>x.TravelAgency.Name == travelAgencyName)
                .ToList();
            return customerList;
        }
    }
}
