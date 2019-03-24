## 1.Architecture
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
Install-Package Microsoft.EntityFrameworkCore.SqlServer -ProjectName DataLayer
Install-Package Microsoft.EntityFrameworkCore.Tools -ProjectName DataLayer
```

## 2. WebApp
Tilføj til StartUp.cs:
```c#
app.UseBrowserLink();
```

For InMemory database tilføjes til service:
```c#
services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
```

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

### 4. ServiceLayer
Tomt
