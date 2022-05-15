using I09UEI_HFT_2021221.Data;
using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;

namespace I09UEI_HFT_2021221.Logic
{
    public class PackageLogic : IPackageLogic
    {
        private IPackageRepository _packageRepository = new PackageRepository(new TravelAgencyDbContext());
        public PackageLogic()
        {
            
        }

        public PackageLogic(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public Package GetOnePackage(int id)
        {
            return _packageRepository.Get(id);
        }

        public IList<Package> GetAllPackages()
        {
            var allPackages = _packageRepository.GetAll().ToList();

            return allPackages;
        }

        public Package AddNewPackage(string name, string category, int price, bool visaNeed, string description, int travelAgencyId)
        {
            var package = new Package()
            {
                Name = name,
                Category = category,
                Price = price,
                VisaNeeded = visaNeed,
                Description = description,
                TravelAgencyId = travelAgencyId
            };

            _packageRepository.Insert(package);

            return package;
        }

        public Package Update(int id, string name, string category, int price, bool visaNeed, string description)
        {
            return _packageRepository.Update(id, name, category, price, visaNeed, description);
        }

        public void DeletePackage(int id)
        {
            _packageRepository.Delete(id);
        }

        public IList<Package> GetPackagesWithCategory(IEnumerable<int> travelAgencies, string category)
        {
            var filteredPackages = _packageRepository
                .GetAll()
                .Where(x => travelAgencies.Contains(x.TravelAgencyId) && x.Category == category)
                .ToList();

            return filteredPackages;
        }

        public IList<Package> GetPackagesVisaNeeded(int travelAgencyId, bool visaNeeded)
        {
            var filteredPackages = _packageRepository
                .GetAll()
                .Where(x => x.TravelAgencyId == travelAgencyId && x.VisaNeeded == visaNeeded)
                .ToList();

            return filteredPackages;
        }

        public IList<Package> GetPackagesAbovePrice(int travelAgencyId, int price)
        {
            var filteredPackages = _packageRepository
                .GetAll()
                .Where(x => x.TravelAgencyId == travelAgencyId && x.Price > price)
                .ToList();

            return filteredPackages;
        }

        public int GetPackageCount()
        {
            return _packageRepository.GetAll().Count();
        }

    }
}
