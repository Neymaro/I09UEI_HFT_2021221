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

        public override TravelAgency Get(int id) => GetAll().SingleOrDefault(x => x.Id == id);

        public override void Insert(TravelAgency obj)
        {
            _context.Set<TravelAgency>().Add(obj);
            _context.SaveChanges();
        }

        public TravelAgency Update(int id, string name, int rating)
        {
            var agency = Get(id);
            if (agency is null)
                throw new InvalidOperationException(" There is no such Travel Agency");

            agency.Name = name;
            agency.Rating = rating;
            _context.SaveChanges();

            return agency;
        }

        public override void Delete(int id)
        {
            TravelAgency obj = Get(id);
            _context.Set<TravelAgency>().Remove(obj);
            _context.SaveChanges();
        }
    }
}
