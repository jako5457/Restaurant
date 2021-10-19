using DataLayer.Entities;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class RestaurantViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public int TotalCount { get; set; }
    }
}
