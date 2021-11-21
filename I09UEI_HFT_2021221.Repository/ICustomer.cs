

namespace I09UEI_HFT_2021221.Repository
{
    class ICustomer
    {
        public interface ICustomers : IRepository<Customers>
        {
            void ChangeName(int id, string newName);

        }
    }
}
