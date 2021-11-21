
using System.ComponentModel.DataAnnotations.Schema;

namespace I09UEI_HFT_2021221.Models
{
    [Table("customers")]
    public class Customers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        [NotMapped]
        public virtual TravelAgencies TravelAgencie { get; set; }

        [ForeignKey(nameof(TravelAgencie))]
        public int? TravelAgencieId { get; set; }
    }
}
