using I09UEI_HFT_2021221.Models;
using System.Linq;

namespace I09UEI_HFT_2021221.Logic
{
    public interface ITravelAgencyLogic
    {
        TravelAgency GetOneAgency(int id);
        IQueryable<TravelAgency> GetAll();
        TravelAgency Create(string name, int point);
        TravelAgency Update(int id, string name, int point);
        void DeleteAgency(int id);
        int GetTravelAgencyCount();
    }
}
