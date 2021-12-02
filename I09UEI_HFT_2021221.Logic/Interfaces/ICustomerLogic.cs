using I09UEI_HFT_2021221.Models;
using System.Linq;


namespace I09UEI_HFT_2021221.Logic
{
    public interface ICustomerLogic
    {
        Customer UpdateCustomer(int id, string newName, int phoneNumber);

        void DeleteCustomer(int id);

        Customer GetCustomer(int id);

        IQueryable<Customer> GetAll();

        Customer AddNew(string customerName, int phone);
    }
}
