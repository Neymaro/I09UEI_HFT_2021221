using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace I09UEI_HFT_2021221.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private ICustomerRepository _customerRepository;
        public CustomerLogic(ICustomerRepository customerRepo)
        {
            _customerRepository = customerRepo;
        }

        public Customer UpdateCustomer(int id, string newName, int phoneNumber)
        {
            return _customerRepository.Update(id, newName, phoneNumber);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = _customerRepository.Get(id);
            if (customer is not null)
                _customerRepository.Delete(id);
        }

        public IQueryable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
        public Customer GetCustomer(int id)
        {
            Customer customer = _customerRepository.Get(id);

            return customer;
        }

        public IList<Customer> GetCustomersStartsWithPhoneNumber(int travelAgencyId, string phoneNumber)
        {
            var customers = _customerRepository
                .GetAll()
                .Where(x => x.TravelAgencyId == travelAgencyId 
                && x.Phone.ToString().StartsWith(phoneNumber))
                .ToList();

            return customers;
        }

        public IList<Customer> GetCustomersWithPhoneNumberMaxLength(int travelAgencyId, int phoneNumberMaxLength)
        {
            var customers = _customerRepository
                .GetAll()
                .Where(x => x.TravelAgencyId == travelAgencyId 
                && x.Phone.ToString().Length <= phoneNumberMaxLength)
                .ToList();

            return customers;
        }

        public Customer AddNew(string customerName, int phone, int travelAgencyId)
        {
            Customer customer = new()
            {
                Name = customerName,
                Phone = phone,
                TravelAgencyId = travelAgencyId
            };
            _customerRepository.Insert(customer);

            return customer;
        }
    }
}