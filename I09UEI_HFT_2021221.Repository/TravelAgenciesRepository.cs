using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Repository
{
    public class TravelAgengiesRepository : Repository<TravelAgengies>, ITravelAgencies
    {
        public TravelAgencies(DbContext ctx) : base(ctx)
        {
        }

        public override void AddNew(TravelAgencies obj)
        {
            this.Ctx.Set<TravelAgencies>().Add(obj);
            this.Ctx.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var pimp = this.ListOne(id);
            if (pimp == null)
            {
                throw new InvalidOperationException(" There is no such Travel Agency");
            }

            pimp.Name = newName;
            this.Ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            TravelAgencies obj = this.ListOne(id);
            this.Ctx.Set<TravelAgencies>().Remove(obj);
            this.Ctx.SaveChanges();
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
                throw new InvalidOperationException("Pimp was not found!");
            }

            travelagency.CustomerRating = newRating;
            this.Ctx.SaveChanges();
        }
    }
}
