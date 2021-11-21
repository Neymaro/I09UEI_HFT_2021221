namespace I09UEI_HFT_2021221.Repository
{
    
        public interface IPackages : IRepository<Packages>
        {
            void ChangeName(int id, string newName);

            void UpdateCustomerRating(int id, int newRating);

        }
    
}
