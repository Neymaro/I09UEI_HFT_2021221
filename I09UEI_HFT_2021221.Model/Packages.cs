using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Models
{
    [Table("packages")]
    public class Packages
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public string Category { get; set; }

        public int Price { get; set; }

        public string VisaType { get; set; }

        public string Description { get; set;  }


        [NotMapped]
        public virtual TravelAgencies TravelAgencie { get; set; }

        [ForeignKey(nameof(TravelAgencie))]
        public int? TravelAgencieId { get; set; }
    }

}