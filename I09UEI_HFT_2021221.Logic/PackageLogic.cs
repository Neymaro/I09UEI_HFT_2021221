using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using System.Linq;

namespace I09UEI_HFT_2021221.Logic
{
    public class PackageLogic : IPackageLogic
    {
        private IPackageRepository _packageRepository;

        public PackageLogic(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public Package AddNewPackage(string name, string category, int price, bool visaNeed, string description)
        {
            var package = new Package()
            {
                Name = name,
                Category = category,
                Price = price,
                VisaNeeded = visaNeed,
                Description = description
            };

            _packageRepository.Insert(package);

            return package;
        }

        public void ChangePackageName(int id, string newName)
        {
            _packageRepository.ChangeName(id, newName);
        }

        public void DeletePackage(int id)
        {
            _packageRepository.Delete(id);
        }

        public IQueryable<Package> GetAllPackages()
        {
            return _packageRepository.GetAll();
        }

        public Package GetOnePackage(int id)
        {
            return _packageRepository.Get(id);
        }
    }
}
