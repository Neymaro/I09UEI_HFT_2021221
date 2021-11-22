using System;
using System.Collections.Generic;
using System.Linq;
using I09UEI_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Repository
{
    public class TravelAgengiesRepository : Repository<TravelAgengies>, ITravelAgencies
    {
        public TravelAgencies(DbContext context) : base(context)
        {
        }

        public override void AddNew(TravelAgencies obj)
        {
            this.context.Set<TravelAgencies>().Add(obj);
            this.context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var agency = this.ListOne(id);
            if (agency == null)
            {
                throw new InvalidOperationException(" There is no such Travel Agency");
            }

            agency.Name = newName;
            this.context.SaveChanges();
        }

        public override void Delete(int id)
        {
            TravelAgencies obj = this.ListOne(id);
            this.context.Set<TravelAgencies>().Remove(obj);
            this.context.SaveChanges();
        }

        public override TravelAgencies ListOne(int id)
        {
            return this.ListAll().SingleOrDefault(x => x.Id == id);
        }

        public void UpdateCustomerRating(int id, int newRating)
        {
            var travelagency = this.ListOne(id);
            if (travelagency == null)
            {
                throw new InvalidOperationException("Are you sure? We could not find any Travel Agency..");
            }

            travelagency.CustomerRating = newRating;
            this.context.SaveChanges();
        }
    }
}
