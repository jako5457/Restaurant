# 2.ListOfRestaurants

Her sker følgende:
- Opret Entiteter
- Data Seeding
- Service interface, class and methods
- ListView and Dependency Injection


### DataLayer
Opret klasserne i *Entities* folderen:
```c#
public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public CuisineType Cuisine { get; set; }
}

public enum CuisineType
{
    None,
    Mexican,
    Italian,
    Indian
}
```

Opret ```DbSet<Restaurant>``` og DataSeeding i AppDbContext.cs:
```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Restaurant>().HasData(
        new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
        new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Italian },
        new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican }
    );
}
```
 
### ServiceLayer
Opret interface og implementering af service:
```c#
public interface IRestaurantService
{
    IQueryable<Restaurant> GetRestaurants();
}

public class RestaurantService : IRestaurantService
{
    private readonly AppDbContext _ctx;
 
    public RestaurantService(AppDbContext ctx)
    {
        ctx.Database.EnsureCreated();
        _ctx = ctx;
    }
    public IQueryable<Restaurant> GetRestaurants() 
    {
        return _ctx.Restaurants;
    }
}
```

Bemærk ```ctx.Database.EnsureCreated()```, som sikrer at ```OnModelCreating()``` bliver kørt og InMemory databasen bliver initialiseret. Fjernes ved brug af manuel Migration.


### WebApp
Opret folder **Pages | Restaurants**
Opret Razor Page kaldet **List**:
```html
<table class="table">
    @foreach (var restaurant in Model.Restaurants)
    {
        <tr>
            <td>@restaurant.Name</td>
            <td>@restaurant.Location</td>
            <td>@restaurant.Cuisine</td>
        </tr>
    }
</table>
```

View:
```c#
public class ListModel : PageModel
{
    public IEnumerable<Restaurant> Restaurants { get; set; }
  
    private readonly IRestaurantService _restaurantService;
 
    public ListModel(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
 
 
    public void OnGet()
    {
        Restaurants = _restaurantService.GetRestaurants().ToList();
    }
}
```

Her kan også benyttes Method-injection: 
```c#
public void OnGet([FromServices] IRestaurantService _restaurantService)
```

Tilføj evt. Restaurants til menuen i _Layout.cshtml.
