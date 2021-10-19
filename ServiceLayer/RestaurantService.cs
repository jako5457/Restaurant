using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;
using System.Linq;

namespace ServiceLayer
{
    public class RestaurantService : IRestaurantService
    {
        private readonly AppDbContext _ctx;

        public RestaurantService(AppDbContext ctx)
        {
            ctx.Database.EnsureCreated();
            _ctx = ctx;
        }

        public IQueryable<Restaurant> GetRestaurants()
        {
            return _ctx.Restaurants;
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return _ctx.Restaurants.Find(restaurantId);
        }

        public RestaurantViewModel GetRestaurantsByName(string searchTerm, int currentPage, int pageSize)
        {
            RestaurantViewModel restaurantVM = new RestaurantViewModel();
            var query = _ctx.Restaurants.AsNoTracking();
            query = searchTerm != null ? query.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower())).OrderBy(r => r.Name) : query;

            restaurantVM.TotalCount = query.Count();

            restaurantVM.Restaurants = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return restaurantVM;
        }
    }
}
