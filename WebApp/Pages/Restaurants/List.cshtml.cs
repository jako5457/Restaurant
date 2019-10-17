using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public const string SessionKeyLastReviewed = "_Mark";
        public int? SessionInfo_LastReviewed { get; private set; }

        public string Message { get; set; }
        public IList<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        private readonly IRestaurantService _restaurantService;

        public ListModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public void OnGet()
        {
            Restaurants = _restaurantService.GetRestaurantsByName(SearchTerm).ToList();
        }
    }
}