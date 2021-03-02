using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Core.DAL
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Id=1, Name="BBQ nations", Location="Bypass Road, Trivandrum", Cuisine=CuisineType.Italian},
                new Restaurant(){ Id=2, Name="Le meridian", Location="Technopark service road,Kazhakootam, Trivandrum", Cuisine=CuisineType.Indian},
                new Restaurant(){ Id=3, Name="Scott Stall", Location="Tennessee Road, Texas", Cuisine=CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name= null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLowerInvariant().StartsWith(name.ToLowerInvariant())
                   orderby r.Name
                   select r;
        }
    }
}
