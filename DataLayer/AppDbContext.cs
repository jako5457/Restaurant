using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 4, Name = "Noma", Location = "Copenhagen", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 5, Name = "Kong Hans Kælder", Location = "Copenhagen", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 6, Name = "Geranium", Location = "Copenhagen", Cuisine = CuisineType.Mexican }
           );
        }
    }

}
