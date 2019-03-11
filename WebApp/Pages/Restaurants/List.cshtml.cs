using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string SearchTerm { get; set; }


        private readonly IRestaurantService _restaurantService;

        public ListModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }


        #region UDEN MODELBINDING
        public void OnGet()
        {
            string searchTerm = HttpContext.Request.QueryString.Value.Split('=').LastOrDefault();

            Restaurants = _restaurantService.GetRestaurantsByName(searchTerm).ToList();
        }
        #endregion

        #region MED MODELBINDING
        //public void OnGet(string SearchTerm)
        //public void OnGet()
        //{
        //    Restaurants = _restaurantService.GetRestaurantsByName(SearchTerm).ToList();
        //}
        #endregion
    }
}