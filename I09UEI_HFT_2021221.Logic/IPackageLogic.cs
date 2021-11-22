using I09UEI_HFT_2021221.Models;
using System.Linq;

namespace I09UEI_HFT_2021221.Logic
{
    public interface IPackageLogic
    {
        void ChangePackageName(int id, string newName);

        void DeletePackage(int id);

        Package GetOnePackage(int id);

        IQueryable<Package> GetAllPackages();

        Package AddNewPackage(string name, string category, int price, bool visaNeed, string description);
    }
}
