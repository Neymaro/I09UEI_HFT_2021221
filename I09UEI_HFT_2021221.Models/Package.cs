using System.Text.Json.Serialization;

namespace I09UEI_HFT_2021221.Models
{
    public class Package
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public bool VisaNeeded { get; set; }

        public string Description { get; set; }

        public int TravelAgencyId { get; set; }
        [JsonIgnore]
        public virtual TravelAgency TravelAgency { get; set; }
    }

}