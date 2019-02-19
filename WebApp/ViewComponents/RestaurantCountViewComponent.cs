using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace WebApp.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantCountViewComponent(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public IViewComponentResult Invoke()
        {
            var count = _restaurantService.GetCountOfRestaurants();
            return View(count);
        }
    }
}
