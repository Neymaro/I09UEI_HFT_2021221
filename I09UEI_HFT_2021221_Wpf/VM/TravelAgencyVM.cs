using GalaSoft.MvvmLight;
using I09UEI_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.VM
{
    public class TravelAgencyVM : ObservableObject
    {
        private int id;
        
        public string name;

        public int rating;

        

        public int Id
        {
            get { return this.id; }
            set { this.Set(ref this.id, value); }
        }

        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        public int Rating
        {
            get { return this.rating; }
            set { this.Set(ref this.rating, value); }
        }

        public void CopyFrom(TravelAgencyVM other)
        {
            this.GetType().GetProperties().ToList().ForEach(property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
