using I09UEI_HFT_2021221_Wpf.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.BL
{
    public interface ITravelAgencyLogicBL
    {
        bool AddTravelAgency(TravelAgencyVM travelAgency,ref int id);

        
        bool ModTravelAgency(TravelAgencyVM travelAgencyToModify);


        bool DelTravelAgency(int travelAgencyId);

      
        public IList<TravelAgencyVM> GetTravelAgencies();

        int GetTravelAgencyCount();
    }
}
