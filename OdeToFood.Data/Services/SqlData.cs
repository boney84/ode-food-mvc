using Microsoft.EntityFrameworkCore;
using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;

namespace OdeToFood.Data.Services
{
    public class SqlData : IRestaurantData
    {
        private OdetofoodDbContext _dbContext;
        public SqlData(OdetofoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Restaurant restaurant)
        {
            _dbContext.Add(restaurant);
            return _dbContext.SaveChanges() > 0;
        }

        public Restaurant Get(int id)
        {
            return _dbContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
           //return from r in _dbContext.Restaurants orderby r.Name select r;
           return _dbContext.Restaurants.AsQueryable();
        }

        public bool Update(Restaurant restaurant)
        {
            bool _statusFlag = false;
            var _dbEntity = Get(restaurant.Id);
            if (_dbEntity != null)
            {
                _dbEntity.Name = restaurant.Name;
                _dbEntity.Cuisine = restaurant.Cuisine;
                _dbContext.Update(_dbEntity);
                _statusFlag = _dbContext.SaveChanges() > 0;
            }

            //var entry = _dbContext.Entry(restaurant);
            //entry.State = EntityState.Modified;
           
            return _statusFlag;
        }
    }
}
