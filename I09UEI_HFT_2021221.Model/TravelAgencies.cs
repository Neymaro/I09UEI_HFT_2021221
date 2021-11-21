using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace I09UEI_HFT_2021221.Models
{
    [Table("travelagencies")]
    public class TravelAgencies
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(35)]
        [Required]
        public string Name { get; set; }

        [MaxLength(3)]
        [Required]
        public int PossitiveComments { get; set; }

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
