using I09UEI_HFT_2021221.Models;

namespace I09UEI_HFT_2021221.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void ChangeName(int id, string newName);
    }
}