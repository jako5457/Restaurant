using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Påkrævet")]
        [StringLength(80, ErrorMessage = "Maks. 80 karakterer")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}

