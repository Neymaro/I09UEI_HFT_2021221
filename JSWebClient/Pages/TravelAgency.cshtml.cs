using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSWebClient.Pages
{
    public class TravelAgencyModel : PageModel
    {
        private readonly ILogger<TravelAgencyModel> _logger;

        public TravelAgencyModel(ILogger<TravelAgencyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
