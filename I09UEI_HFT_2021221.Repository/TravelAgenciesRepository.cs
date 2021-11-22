using System;
using System.Linq;
using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace I09UEI_HFT_2021221.Repository
{
    public class TravelAgencyRepository : Repository<TravelAgency>, ITravelAgencies
    {
        public TravelAgencyRepository(DbContext context) : base(context)
        {
        }

        public override void Insert(TravelAgency obj)
        {
            Context.Set<TravelAgency>().Add(obj);
            Context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var agency = Get(id);
            if (agency is null)
            {
                throw new InvalidOperationException(" There is no such Travel Agency");
            }

            agency.Name = newName;
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            TravelAgency obj = Get(id);
            Context.Set<TravelAgency>().Remove(obj);
            Context.SaveChanges();
        }

        public override TravelAgency Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public void UpdatePointOfAgency(int id, int newPoint)
        {
            var travelagency = Get(id);
            if (travelagency is null)
            {
                throw new InvalidOperationException("Are you sure? We could not find any Travel Agency..");
            }

            travelagency.PointOfAgency = newPoint;
            Context.SaveChanges();
        }
    }
}
