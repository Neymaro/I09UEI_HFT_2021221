using I09UEI_HFT_2021221.Models;
using System.Linq;

namespace I09UEI_HFT_2021221.Logic
{
    public interface ITravelAgencyLogic
    {
        void ChangeName(int id, string newName);

        void DeleteAgency(int id);

        TravelAgency GetOneAgency(int id);

        IQueryable<TravelAgency> GetAllAgencies();

        TravelAgency AddNewTravelAgency(string name, int point);
    }
}
