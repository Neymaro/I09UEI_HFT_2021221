namespace I09UEI_HFT_2021221.Models.Dtos
{
    public record PackagePutDto(
        int Id,
        string Name,
        string Category,
        int Price,
        bool VisaNeeded,
        string Description);
}
