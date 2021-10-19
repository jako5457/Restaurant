# SearchingPaging
Denne branch viser Search kombineret med Paging.

Ref: [Simple Paging In ASP.NET Core Razor Pages](https://www.mikesdotnetting.com/article/328/simple-paging-in-asp-net-core-razor-pages)

## ServiceLayer

Der oprettes en ViewModel i Models-folderen:

```csharp
using DataLayer.Entities;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class RestaurantViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public int TotalCount { get; set; }
    }
}
```

&nbsp;

RestaurantServicen udbygges med metoden `GetRestaurantsByName(string searchTerm, int currentPage, int pageSize)`:

```csharp
public RestaurantViewModel GetRestaurantsByName(string searchTerm, int currentPage, int pageSize)
{
    RestaurantViewModel restaurantVM = new RestaurantViewModel();
    var query = _ctx.Restaurants.AsNoTracking();
    query = searchTerm != null ? query.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower())).OrderBy(r => r.Name) : query;

    restaurantVM.TotalCount = query.Count();

    restaurantVM.Restaurants = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

    return restaurantVM;
}
```

&nbsp;

## WebApp

PageModel udvides med følgende properties og en Enum:

```csharp
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
```

I OnGet() tilføjes følgende:

```csharp
public void OnGet()
{
    RestaurantViewModel restaurantVM = _restaurantService.GetRestaurantsByName(SearchTerm, CurrentPage, PageSize);
    Restaurants = restaurantVM.Restaurants;
    Count = restaurantVM.TotalCount;
}
```

I Razor pagen tilføjes følgende:

```html
<tbody>
    @foreach (var restaurant in Model.Restaurants)
    {
        <tr>
            <td>@restaurant.Name</td>
            <td>@restaurant.Location</td>
            <td>@restaurant.Cuisine</td>
            <td>
                    <a asp-page="./Detail" asp-route-restaurantId="@restaurant.Id">
                        <i class="fas fa-info-circle"></i>
                    </a>
                </td>
        </tr>
    }
</tbody>
```



