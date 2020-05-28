using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public List<Restaurant> Restaurants { get; set; }

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

            foreach (Restaurant? item in Restaurants)
            {
                if (item.ImageData != null)
                {
                    string imageBase64Data = Convert.ToBase64String(item.ImageData);
                    string imageDataUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
                    item.ImageUrl = imageDataUrl;
                }
               
            }

        }
    }
}