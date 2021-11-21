using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace I09UEI_HFT_2021221.Models
{
    [Table("travelagencies")]
    public class TravelAgencies
    {

     
        public int Id { get; set; }
       
        public string Name { get; set; }

        public int PointOfAgency { get; set; }

        [NotMapped]
        public virtual ICollection<Packages> Packages { get; }

        [NotMapped]
        public virtual ICollection<Customers> Customers { get; }


        public TravelAgencies()
        {
            this.Packages = new HashSet<Packages>();
            this.Customers = new HashSet<Customers>();
        }
    }
}
