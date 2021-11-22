using System.ComponentModel.DataAnnotations.Schema;


namespace I09UEI_HFT_2021221.Models
{
    [Table("packages")]
    public class Packages
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public bool VisaNeeded { get; set; }

        public string Description { get; set;  }


        [NotMapped]
        public virtual TravelAgencies TravelAgencie { get; set; }

        [ForeignKey(nameof(TravelAgencie))]
        public int? TravelAgencieId { get; set; }
    }

}