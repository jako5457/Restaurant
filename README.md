# 4.EditingData
Der oprettes en mulighed for at redigere data for restauranterne:

-- Her indsættes billede af Edit-viewet

## ServiceLayer
RestaurantService udvides med en Edit metode:


## WebApp
Her tilføjes...

#### SELECT
Her er benyttet den simple måde at binde en enum til en Select, hvor det alene foregår i View'et. Her benyttes metoden: ```Html.GetEnumSelectList<T>()```:
```xml
<div class="form-group">
    <label asp-for="Restaurant.Cuisine" />
    <select asp-for="Restaurant.Cuisine"
            asp-items="Html.GetEnumSelectList<DataLayer.Entities.CuisineType>()"
            class="form-control"></select>
    <span class="text-danger" asp-validation-for="Restaurant.Cuisine"></span>
</div>
```
#### Alternativ binding til SELECT
En anden måde er at injecte `IHtmlHelper` servicen ind i ViewModel-klassens constructor (kræver import af namespacet: `Microsoft.AspNetCore.Mvc.Rendering`):
```csharp
public IEnumerable<SelectListItem> Cuisines { get; set; }

private IHtmlHelper _htmlHelper;

public EditModel(IRestaurantService restaurantService, IHtmlHelper htmlHelper)
{
    _restaurantService = restaurantService;
    _htmlHelper = htmlHelper;
}
```
I OnGet hentes data ind på følgende måde:
```csharp
Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
```

Og i View'et bindes SELECT kontrollen til Cuisines property:
```xml
asp-items="Model.Cuisines"
```


---
## Post-Redirect-Get Pattern
Beskrivelse