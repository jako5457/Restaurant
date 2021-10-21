# 4.EditingData
Indeholder f�lgende:
> - Edit og Add af Restaurant
> - SELECT kontrollen til valg af Cuisine
> - Validation, b�de server og client-side
> - Post-Redirect-Get Pattern

-- Her inds�ttes billede af Edit-viewet

## Docker

#### Docker compose
K�r denne kommando i roden af projektet
```bash
docker-compose up
```

#### Build
Byg applikation (du skal st� i roden inden du k�rer den)
```bash
docker build -f WebApp/Dockerfile -t restaurants:latest
```
Start App
```bash
docker run -name restaurants -p 80:80 -p 443:443 -e "CONNECTIONSTRING=CONNECTIONSTRING=Server=<SQL SERVER ADDRESSE>;Database=RestaurantDB;User Id=<DATABASE BRUGER>;Password=<DATABASE PASSWORD>;" jako5457/restaurants" restaurants:latest
```

#### Docker hub

```bash
docker run -name restaurants -p 80:80 -p 443:443 -e "CONNECTIONSTRING=Server=<SQL SERVER ADDRESSE>;Database=RestaurantDB;User Id=<DATABASE BRUGER>;Password=<DATABASE PASSWORD>;" jako5457/restaurants
```

## ServiceLayer
RestaurantService udvides med en Edit metode:


## WebApp
Her tilf�jes...

#### SELECT
Her er benyttet den simple m�de at binde en enum til en Select, hvor det alene foreg�r i View'et. Her benyttes metoden ```Html.GetEnumSelectList<T>()```:
```html
<div class="form-group">
    <label asp-for="Restaurant.Cuisine" />
    <select asp-for="Restaurant.Cuisine"
            asp-items="Html.GetEnumSelectList<DataLayer.Entities.CuisineType>()"
            class="form-control">
        <option value="" disabled>Choose Cuisine</option>
    </select>
</div>
```
#### Alternativ binding til SELECT
En anden m�de er at injecte `IHtmlHelper` servicen ind i ViewModel-klassens constructor (kr�ver import af namespacet: `Microsoft.AspNetCore.Mvc.Rendering`):
```csharp
public IEnumerable<SelectListItem> Cuisines { get; set; }

private IHtmlHelper _htmlHelper;

public EditModel(IRestaurantService restaurantService, IHtmlHelper htmlHelper)
{
    _restaurantService = restaurantService;
    _htmlHelper = htmlHelper;
}
```
I `OnGet` hentes data ind p� f�lgende m�de:
```csharp
Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
```

Og i View'et bindes SELECT kontrollen til Cuisines property:
```xml
asp-items="Model.Cuisines"
```

&nbsp;

## Validation
Der er sat Data Annotations p� model-klassen i DataLayer projektet:
```c#
public int Id { get; set; }

[Required(ErrorMessage = "P�kr�vet")]
[StringLength(80, ErrorMessage = "Maks. 80 karakterer")]
public string Name { get; set; }

[Required, StringLength(255)]
public string Location { get; set; }

public CuisineType Cuisine { get; set; }
}
```

Det er vigtigt at teste om alle valideringer er gennemf�rt med succes og det sker ved at kigge p� `ModelState.IsValid`:
```c#
public IActionResult OnPost()
{
    if (!ModelState.IsValid)
    {
        return Page();            
    }
    if (Restaurant.Id > 0)
    {
        _restaurantService.Update(Restaurant);
    }
    else
    {
        _restaurantService.Add(Restaurant);
    }
    _restaurantService.Commit();   
}
```

&nbsp;

## Post-Redirect-Get Pattern
Beskrivelse

```c#
return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
```

