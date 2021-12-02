using System;
using System.Linq;
using I09UEI_HFT_2021221.Data;
using I09UEI_HFT_2021221.Models;

namespace I09UEI_HFT_2021221.Repository
{
    public class TravelAgencyRepository : Repository<TravelAgency>, ITravelAgencyRepository
    {
        private readonly TravelAgencyDbContext _context;

        public TravelAgencyRepository(TravelAgencyDbContext context) : base(context)
        {
            _context = context;
        }

        public override void Insert(TravelAgency obj)
        {
            _context.Set<TravelAgency>().Add(obj);
            _context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var agency = Get(id);
            if (agency is null)
                throw new InvalidOperationException(" There is no such Travel Agency");

            agency.Name = newName;
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            TravelAgency obj = Get(id);
            _context.Set<TravelAgency>().Remove(obj);
            _context.SaveChanges();
        }

        public override TravelAgency Get(int id) => GetAll().SingleOrDefault(x => x.Id == id);

        public void UpdatePointOfAgency(int id, int newPoint)
        {
            var travelagency = Get(id);
            if (travelagency is null)
                throw new InvalidOperationException("Are you sure? We could not find any Travel Agency..");

            travelagency.Rating = newPoint;
            _context.SaveChanges();
        }
    }
}
