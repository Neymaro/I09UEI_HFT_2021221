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

        public TravelAgency GetOneAgency(int id)
        {
            TravelAgency travelAgency = _travelAgencyRepository.Get(id);

            return travelAgency;
        }

        
        public IQueryable<TravelAgency> GetAll() => _travelAgencyRepository.GetAll() ;
        
        public TravelAgency Create(string name, int point)
        {
            TravelAgency travelAgency = new()
            {
                Name = name,
                Rating = point
            };
            _travelAgencyRepository.Insert(travelAgency);

            return travelAgency;
        }

        public TravelAgency Update(int id, string newName, int rating)
        {
            var travelAgency = _travelAgencyRepository.Update(id, newName, rating);

            return travelAgency;
        }

        public void DeleteAgency(int id)
        {
            TravelAgency travelAgency = _travelAgencyRepository.Get(id);
            if (travelAgency is null)
                throw new InvalidOperationException(" No record!");
            else
                _travelAgencyRepository.Delete(id);
        }


    }
}
