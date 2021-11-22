using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using System;
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

        public void ChangeCustomerName(int id, string newName)
        {
            _customerRepository.ChangeName(id, newName);
        }

        public void ChangeCustomerPhone(int id, int newPhone)
        {
            _customerRepository.ChangeCustomerPhone(id, newPhone);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = _customerRepository.Get(id);
            if (customer is null)
                throw new InvalidOperationException("ERROR: No corresponding record!");
            else
                _customerRepository.Delete(id);
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetOneCustomer(int id)
        {
            Customer customer = _customerRepository.Get(id);
            if (customer is null)
                throw new InvalidOperationException("ERROR: No corresponding record!");

            return customer;
        }

        public Customer AddNewCustomer(string customername, int phone)
        {
            Customer customer = new()
            {
                Name = customername,
                Phone = phone
            };
            _customerRepository.Insert(customer);
            return customer;
        }
    }
}