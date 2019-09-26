using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public const string SessionKeyLastReviewed = "_Mark";
        public int? SessionInfo_LastReviewed { get; private set; }

        public Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }

        private readonly IRestaurantService _restaurantService;

        public DetailModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantService.GetRestaurantById(restaurantId);

            #region SESSION DEMO
            // Requires: using Microsoft.AspNetCore.Http;
            {
                HttpContext.Session.SetInt32(SessionKeyLastReviewed, Restaurant.Id); 
            }

            // Local test of Session variable
            SessionInfo_LastReviewed = HttpContext.Session.GetInt32(SessionKeyLastReviewed);
            #endregion

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}