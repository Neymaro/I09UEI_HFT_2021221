using I09UEI_HFT_2021221.Models;
using System.Collections.Generic;

namespace I09UEI_HFT_2021221.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Update(int id, string newName, int phoneNumber);

        IList<Customer> GetCustomersOfTravelAgency(string travelAgencyName);
    }

    
}