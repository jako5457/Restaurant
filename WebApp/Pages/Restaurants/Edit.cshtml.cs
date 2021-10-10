using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using ServiceLayer;
using System.IO;
using System.Threading.Tasks;

namespace WebApp.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        [BindProperty]
        public IFormFile FormFile { get; set; }

        private readonly IRestaurantService _restaurantService;

        public EditModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantService.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            if (Restaurant.Id > 0)
            {
                await UploadFetchImageAsync(Restaurant.Id);
                _restaurantService.Update(Restaurant);
                _restaurantService.Commit();
            }
            else
            {
                _restaurantService.Add(Restaurant);
                _restaurantService.Commit();
                await UploadFetchImageAsync(Restaurant.Id);
            }

            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }

        public async Task<IActionResult> UploadFetchImageAsync(int id)
        {
            if (FormFile?.Length > 0)
            {
                var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img")).Root + $@"{id}.jpg";

                using (var stream = System.IO.File.Create(filepath))
                {
                    await FormFile.CopyToAsync(stream);
                }
            }
            return Page();
        }
    }
}