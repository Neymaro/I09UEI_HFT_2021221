using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
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
            var customer = _customerRepository.Get(id);
            return customer;
        }

        public Customer AddNew(string customerName, int phone)
        {
            Customer customer = new()
            {
                Name = customerName,
                Phone = phone
            };
            _customerRepository.Insert(customer);

            return customer;
        }
    }
}