using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Id=1, Name="Scott's pizza", Cuisine=CuisineType.Italian},
                new Restaurant(){ Id=2, Name="BarbeQue", Cuisine=CuisineType.Continental},
                new Restaurant(){ Id=3, Name="Mango Grove", Cuisine=CuisineType.Indian},
                new Restaurant(){ Id=4, Name="Global Inn", Cuisine=CuisineType.Chinese},
            };
        }

        public Restaurant Get(int id)
        {
           return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
          return  restaurants.OrderBy(r=>r.Name);
        }

        public bool Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Select(r => r.Id).Max() + 1;
            return true;
        }

        public bool Update(Restaurant restaurant)
        {
            bool updateStatus = false;
            var dbEntity = Get(restaurant.Id);
            if (dbEntity != null)
            {
                dbEntity.Name = restaurant.Name;
                dbEntity.Cuisine = restaurant.Cuisine;
                updateStatus = true;
            }
           
            return updateStatus;
        }
    }
}
