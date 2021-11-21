using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using I09UEI_HFT_2021221.Models;

namespace I09UEI_HFT_2021221.Repository
{
    public class CustomersRepository : Repository<Customers>, ICustomer
    {
        
    }
}
