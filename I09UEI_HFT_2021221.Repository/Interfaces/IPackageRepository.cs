using I09UEI_HFT_2021221.Models;

namespace I09UEI_HFT_2021221.Repository
{
    public interface IPackageRepository : IRepository<Package>
    {
        Package Update(int id, string name, string category, int price, bool visaNeed, string description);

        void VisaNeeded(int id, bool hasVisa);
    }
}
