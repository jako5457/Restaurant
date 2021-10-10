## 1.Architecture

Denne tutorial benytter **.NET 5.0** til WebApp og **.NET Standard 2.1** til classlibraies.

Opret følgende projekter
* WebApp (Razor Pages Web App)
* ServiceLayer (.NET Standard class library)
* DataLayer (.NET Standard class library)

Opret projekt referencerne:
* WebApp -> DataLayer og ServiceLayer
* ServiceLayer -> DataLayer


Installér følgende NuGet-pakker vha. PMC:
```powershell
Install-Package Microsoft.VisualStudio.Web.BrowserLink -ProjectName WebApp
Install-Package Microsoft.EntityFrameworkCore.InMemory -ProjectName WebApp
Install-Package Microsoft.EntityFrameworkCore.SqlServer -ProjectName DataLayer
Install-Package Microsoft.EntityFrameworkCore.Tools -ProjectName DataLayer
```
&nbsp;

## 2. WebApp
For InMemory database tilføjes til ConfigureServices:
```c#
services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
```

Tilføj til StartUp.cs under Configure hvis Environment er Developer:
```c#
app.UseBrowserLink();
```
&nbsp;

## 3. DataLayer
Opret AppDbContext.cs med følgende indhold:

```C#
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
```

Opret folder kaldet *Entities*.

&nbsp;

### 4. ServiceLayer
Tomt
