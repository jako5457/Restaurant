using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public IList<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        #region PAGINATION
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        public int Count { get; set; }

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public enum PageSizeEnum
        {
            [Display(Name = "2")]
            _2 = 2,
            [Display(Name = "4")]
            _4 = 4,
            [Display(Name = "10")]
            _10 = 10,
        }
        #endregion

        private readonly IRestaurantService _restaurantService;
        public ListModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public void OnGet()
        {
            RestaurantViewModel restaurantVM = _restaurantService.GetRestaurantsByName(SearchTerm, CurrentPage, PageSize);
            Restaurants = restaurantVM.Restaurants;
            Count = restaurantVM.TotalCount;
        }
    }
}