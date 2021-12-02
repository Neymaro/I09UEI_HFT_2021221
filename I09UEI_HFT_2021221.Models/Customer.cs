using System.Text.Json.Serialization;

namespace I09UEI_HFT_2021221.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public int? TravelAgencyId { get; set; }
        [JsonIgnore]
        public virtual TravelAgency TravelAgency { get; set; }
    }
}
