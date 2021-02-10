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
        public IEnumerable<Restaurant> GetAll()
        {
          return  restaurants.OrderBy(r=>r.Name);
        }
    }
}
