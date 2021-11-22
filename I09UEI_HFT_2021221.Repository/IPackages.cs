using I09UEI_HFT_2021221.Models;

namespace I09UEI_HFT_2021221.Repository
{

    public interface IPackages : IRepository<Packages>
    {
        void ChangeName(int id, string newName);

        void ChangeCategory(int id, string newCategory);

        void ChangePrice(int id, int newPrice);

        void VisaNeeded(int id, bool hasVisa);

    }

}
