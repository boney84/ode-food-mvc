using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Core.DAL;

namespace OdeToFood.RazorWeb.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantService;

        public ListModel(IConfiguration config, IRestaurantData restaurantService)
        {
            this.config = config;
            this.restaurantService = restaurantService;
        }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; set; }
        
        [BindProperty]
        public string SearchTerm { get; set; }
        public void OnGet(string SearchTerm)
        {
            Restaurants = restaurantService.GetRestaurantsByName(SearchTerm);
        }
    }
}
