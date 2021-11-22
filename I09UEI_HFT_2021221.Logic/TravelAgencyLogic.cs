using I09UEI_HFT_2021221.Models;
using I09UEI_HFT_2021221.Repository;
using System;
using System.Linq;

namespace I09UEI_HFT_2021221.Logic
{
    public class TravelAgencyLogic : ITravelAgencyLogic
    {
        private ITravelAgencyRepository _travelAgencyRepository;

        public TravelAgencyLogic(ITravelAgencyRepository travelAgencyRepo)
        {
            _travelAgencyRepository = travelAgencyRepo;
        }

        public void ChangeName(int id, string newName) => _travelAgencyRepository.ChangeName(id, newName);

        public void DeleteAgency(int id)
        {
            TravelAgency travelAgency = _travelAgencyRepository.Get(id);
            if (travelAgency is null)
            {
                throw new InvalidOperationException(" No corresponding record!");
            }
            else
            {
                _travelAgencyRepository.Delete(id);
            }
        }

        public TravelAgency GetOneAgency(int id)
        {
            TravelAgency travelAgency = _travelAgencyRepository.Get(id);
            if (travelAgency is null)
                throw new InvalidOperationException("No corresponding record!");

            return travelAgency;
        }

        public TravelAgency AddNewTravelAgency(string name, int point)
        {
            TravelAgency travelAgency = new()
            {
                Name = name,
                PointOfAgency = point
            };
            _travelAgencyRepository.Insert(travelAgency);

            return travelAgency;
        }

        public IQueryable<TravelAgency> GetAllAgencies() => _travelAgencyRepository.GetAll();
    }
}
