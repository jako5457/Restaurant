using DataLayer.Entities;
using ServiceLayer.Models;
using System.Linq;

namespace ServiceLayer
{
    public interface IRestaurantService
    {
        IQueryable<Restaurant> GetRestaurants();
        public RestaurantViewModel GetRestaurantsByName(string searchTerm, int currentPage, int pageSize);
        Restaurant GetRestaurantById(int restaurantId);
    }
}
