using DataLayer.Entities;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class RestaurantViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public int TotalCount { get; set; }
    }
}
