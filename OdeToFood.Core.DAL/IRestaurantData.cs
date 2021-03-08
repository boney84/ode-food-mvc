using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core.DAL
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Create(Restaurant restaurant);
        Restaurant Delete(int id);
        int Commit();
    }
}
