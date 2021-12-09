using System.Collections.Generic;

namespace I09UEI_HFT_2021221.Models.Dtos
{
    public record PackagesWithCategoryPostDto(IEnumerable<int> TravelAgencyIds, string Category);
}
