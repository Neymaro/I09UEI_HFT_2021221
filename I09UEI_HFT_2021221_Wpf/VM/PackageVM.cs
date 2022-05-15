using GalaSoft.MvvmLight;
using I09UEI_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221_Wpf.VM
{
    public class PackageVM : ObservableObject
    {
        private int id;
        
        public string name;

        public int price;
        public string category;
        public string description;
        public int travelAgencyId;
        public bool visaNeeded;
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
        public bool VisaNeeded
        {
            get { return this.visaNeeded; }
            set { this.Set(ref this.visaNeeded, value); }
        }
        public int Price
        {
            get { return this.price; }
            set { this.Set(ref this.price, value); }
        }
        public string Category
        {
            get { return this.category; }
            set { this.Set(ref this.category, value); }
        }
        public string Description
        {
            get { return this.description; }
            set { this.Set(ref this.description, value); }
        }
        public int TravelAgencyId
        {
            get { return this.travelAgencyId; }
            set { this.Set(ref this.travelAgencyId, value); }
        }
        public void CopyFrom(TravelAgencyVM other)
        {
            this.GetType().GetProperties().ToList().ForEach(property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
