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

        public int Commit()
        {
            return 1;
        }

        public Restaurant Create(Restaurant restaurant)
        {
            int restaurantId = restaurants.Max(r => r.Id) + 1;
            restaurant.Id = restaurantId;
            restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurantEntity = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurantEntity != null)
            {
                restaurants.Remove(restaurantEntity);
            }
            return restaurantEntity;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name= null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLowerInvariant().StartsWith(name.ToLowerInvariant())
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var restaurantEntity = restaurants.FirstOrDefault(r => r.Id == restaurant.Id);
            if (restaurantEntity != null)
            {
                restaurantEntity.Name = restaurant.Name;
                restaurantEntity.Location = restaurant.Location;
                restaurantEntity.Cuisine = restaurant.Cuisine;
            }
            return restaurantEntity;
        }
    }
}
