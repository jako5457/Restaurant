# 8. SessionVariable
[Session state](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.0#session-state)

I Restaurant-eksemplet benyttes en Session-variabel til at huske hvilken restaurant man har besøgt med Detail-pagen - og efter f.eks. 
100 sekunder forsvinder informationen.

I ```Startup.cs```skal følgende tilføjes til ```ConfigureServices()```:
```c#
services.AddDistributedMemoryCache();

services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromSeconds(100);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});
```

Og i ```Configure()``` tilføjes følgende:
```c#
app.UseSession();
```


Her vises hvordan en ```Integer``` skrives til en Session-variabel (øvrig kode er fjernet for at gøre det tydeligere):
```c#
public class DetailModel : PageModel
{
    public const string SessionKeyLastReviewed = "_Mark";
    public int? SessionInfo_LastReviewed { get; private set; }

    public IActionResult OnGet(int restaurantId)
    {
        #region SESSION DEMO
        // Requires: using Microsoft.AspNetCore.Http;
        {
            HttpContext.Session.SetInt32(SessionKeyLastReviewed, Restaurant.Id); 
        }

        // Local test of Session variable
        SessionInfo_LastReviewed = HttpContext.Session.GetInt32(SessionKeyLastReviewed);
        #endregion

        return Page();
    }
}
```

I View'et kan man evt. vise indholdet af Session-variablen vha. den oprettede property:
```html
<div>
    Stored in Session: @Model.SessionInfo_LastReviewed
</div>
```