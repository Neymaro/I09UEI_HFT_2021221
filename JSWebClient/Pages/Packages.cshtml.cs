using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSWebClient.Pages
{
    public class PackagesModel : PageModel
    {
        private readonly ILogger<PackagesModel> _logger;

        public PackagesModel(ILogger<PackagesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
