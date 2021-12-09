using I09UEI_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace I09UEI_HFT_2021221.Test
{
    public static class DbContextHelper
    {
        public static DbContextOptions<TravelAgencyDbContext> GetInMemoryOptions() =>
            new DbContextOptionsBuilder<TravelAgencyDbContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options;
    }
}
