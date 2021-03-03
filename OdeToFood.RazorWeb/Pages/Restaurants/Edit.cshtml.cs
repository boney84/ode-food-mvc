using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Core.DAL;

namespace OdeToFood.RazorWeb.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public IActionResult OnGet(int? Id)
        {
            if (Id.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(Id.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.Id == 0)
            {
                restaurantData.Create(Restaurant);
            }
            else
            {
                restaurantData.Update(Restaurant);
            }

            TempData["Message"] = "Restaurant saved!";
            restaurantData.Commit();
            return RedirectToPage("./Detail",new {Id= Restaurant.Id });
        }

    }
}
