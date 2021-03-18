using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Core.DAL;

namespace OdeToFood.RazorWeb.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantService;
        private readonly ILogger logger;

        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantService,
                         ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantService = restaurantService;
            this.logger = logger;
        }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; set; }
        
        [BindProperty]
        public string SearchTerm { get; set; }
        public void OnGet(string SearchTerm)
        {
            logger.LogError("Executing restaurant list");
            Restaurants = restaurantService.GetRestaurantsByName(SearchTerm);
        }
    }
}
