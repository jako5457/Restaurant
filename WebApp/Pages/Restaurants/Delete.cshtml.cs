using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using ServiceLayer;
using System;
using System.IO;

namespace WebApp.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        private readonly IRestaurantService _restaurantService;

        public DeleteModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantService.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = _restaurantService.Delete(restaurantId);
            _restaurantService.Commit();
            DeleteImage(restaurantId);

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");
        }

        public void DeleteImage(int id)
        {
            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img")).Root + $@"{id}.jpg";

            try
            {
                System.IO.File.Delete(filepath);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
        }
    }
}