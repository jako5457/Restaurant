﻿using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System;

namespace WebApp.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
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

            #region COOKIE DEMO
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                IsEssential = true
            };
            Response.Cookies.Append("MyFavorite", Restaurant.Id.ToString(), cookieOptions);
            #endregion

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}