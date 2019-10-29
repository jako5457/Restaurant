# 4.EditingData
Der oprettes en mulighed for at redigere data for restauranterne:

-- Her indsættes billede af Edit-viewet

### ServiceLayer
RestaurantService udvides med en Edit metode:


### WebApp
Her tilføjes...

Her ses en anden måde at binde en enum til en Select, hvor det alene foregår i View'et. Her benyttes metoden: ```Html.GetEnumSelectList<T>()```:
```c#
<div class="form-group">
    <label asp-for="Restaurant.Cuisine" />
    <select asp-for="Restaurant.Cuisine"
            asp-items="Html.GetEnumSelectList<DataLayer.Entities.CuisineType>()"
            class="form-control"></select>
    <span class="text-danger" asp-validation-for="Restaurant.Cuisine"></span>
</div>
```
---
## Post-Redirect-Get Pattern
Beskrivelse