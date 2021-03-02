using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core.DAL
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }
}
