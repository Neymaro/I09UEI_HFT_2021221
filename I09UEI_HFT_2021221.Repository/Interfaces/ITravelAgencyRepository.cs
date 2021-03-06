using I09UEI_HFT_2021221.Models;

namespace I09UEI_HFT_2021221.Repository
{
    public interface ITravelAgencyRepository : IRepository<TravelAgency>
    {
        TravelAgency Update(int id, string name, int rating);
    }
}
