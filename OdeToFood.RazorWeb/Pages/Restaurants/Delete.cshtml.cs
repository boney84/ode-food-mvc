using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Core.DAL;

namespace OdeToFood.RazorWeb.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public Restaurant Restaurant { get; set; }

        public IActionResult OnGet(int Id)
        {
           Restaurant = restaurantData.GetRestaurantById(Id);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int Id)
        {
            var restaurant = restaurantData.Delete(Id);
            restaurantData.Commit();
            if (restaurant == null)
            {
                return RedirectToPage("./NoFound");
            }

            TempData["Message"] = $"Restaurant {restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}
