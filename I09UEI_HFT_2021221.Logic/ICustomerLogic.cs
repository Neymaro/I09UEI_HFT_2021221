using I09UEI_HFT_2021221.Models;
using System.Linq;


namespace I09UEI_HFT_2021221.Logic
{
    public interface ICustomerLogic
    {
        void ChangeCustomerName(int id, string newName);

        void ChangeCustomerPhone(int id, int newPhone);

        void DeleteCustomer(int id);

        Customer GetOneCustomer(int id);

        IQueryable<Customer> GetAllCustomers();

        Customer AddNewCustomer(string customerName, int phone);
    }
}
