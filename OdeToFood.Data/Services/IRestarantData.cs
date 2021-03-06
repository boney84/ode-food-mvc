﻿using OdeToFood.Data.Models;
using System.Collections.Generic;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant Get(int id);

        bool Add(Restaurant restaurant);
        bool Update(Restaurant restaurant);
    }
}
