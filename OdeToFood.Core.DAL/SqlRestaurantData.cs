using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Core.DAL
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbcontext dbcontext;

        public SqlRestaurantData(OdeToFoodDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public int Commit()
        {
           return dbcontext.SaveChanges();
        }

        public Restaurant Create(Restaurant restaurant)
        {
            dbcontext.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurantEntity = GetRestaurantById(id);
            if (restaurantEntity != null)
            {
                dbcontext.Remove(restaurantEntity);
            }
           
            return restaurantEntity;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return dbcontext.Restaurants.FirstOrDefault(r=>r.Id== id);
        }

        public int GetRestaurantCount()
        {
            return dbcontext.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
           return dbcontext.Restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.Contains(name)).OrderBy(s=>s.Name);
        }

        public Restaurant Update(Restaurant restaurant)
        {

             //Approach 1
            //var restaurantEntity = GetRestaurantById(restaurant.Id);
            //if (restaurantEntity != null)
            //{
            //    restaurantEntity.Name = restaurant.Name;
            //    restaurantEntity.Cuisine = restaurant.Cuisine;
            //    restaurantEntity.Location = restaurant.Location;
            //    dbcontext.Restaurants.Update(restaurantEntity);
            //}

            //Approch 2
            var entity = dbcontext.Restaurants.Attach(restaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return restaurant;
        }
    }
}
