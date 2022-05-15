using I09UEI_HFT_2021221.Models;
using System.Collections.Generic;

namespace I09UEI_HFT_2021221.Logic
{
    public interface IPackageLogic
    {
        Package Update(int id, string name, string category, int price, bool visaNeed, string description);

        void DeletePackage(int id);

        Package GetOnePackage(int id);

        IList<Package> GetAllPackages();

        Package AddNewPackage(string name, string category, int price, bool visaNeed, string description, int travelAgencieId);

        IList<Package> GetPackagesWithCategory(IEnumerable<int> travelAgencies, string category);

        IList<Package> GetPackagesVisaNeeded(int travelAgencyId, bool visaNeeded);

        IList<Package> GetPackagesAbovePrice(int travelAgencyId, int price);
        int GetPackageCount();
    }
}
