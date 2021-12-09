using System.Collections.Generic;

namespace I09UEI_HFT_2021221.Models
{
    public class TravelAgency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public virtual ICollection<Package> Packages { get; }

        public virtual ICollection<Customer> Customers { get; }
    }
}
