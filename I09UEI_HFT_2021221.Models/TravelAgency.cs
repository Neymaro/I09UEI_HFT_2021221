using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace I09UEI_HFT_2021221.Models
{
    [Table("travelAgencies")]
    public class TravelAgency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PointOfAgency { get; set; }

        [NotMapped]
        public virtual ICollection<Package> Packages { get; }

        [NotMapped]
        public virtual ICollection<Customer> Customers { get; }

        public TravelAgency()
        {
            Packages = new HashSet<Package>();
            Customers = new HashSet<Customer>();
        }
    }
}
