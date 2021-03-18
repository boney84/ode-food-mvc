using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood.RazorWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IConfiguration config, ILogger<IndexModel> logger)
        {
            this.config = config;
            _logger = logger;
        }

        public string Message { get; set; }

        public void OnGet()
        {
           Message = config["Message"];
        }
    }
}
