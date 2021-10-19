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
                new Restaurant { Id = 4, Name = "The Boheme", Location = "Switzerland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 5, Name = "Apple Club", Location = "London", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 6, Name = "La Viva", Location = "Spain", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 7, Name = "Egons's Pizza", Location = "Denmark", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 8, Name = "Stay away Pizza", Location = "Berlin", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 9, Name = "Bon Appetite Pizza", Location = "Rome", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 10, Name = "Strangers Pizza", Location = "New York", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 11, Name = "The Dark Side Pizza", Location = "Moscow", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 12, Name = "Pizza Club", Location = "California", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 13, Name = "The Kitchen", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 14, Name = "Take Away", Location = "London", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 15, Name = "Wow", Location = "California", Cuisine = CuisineType.Mexican }
           );
        }
    }

}
