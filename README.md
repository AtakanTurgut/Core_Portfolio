# Core_Project
This website is my portfolio.

## Project Layers
``` cs
EntityLayer
DataAccessLayer => EntityLayer
BusinessLayer   => EntityLayer + DataAccessLayer
CoreProject     => EntityLayer + DataAccessLayer + BusinessLayer 
```

## Addresses
```cs
Web Site    =  https://localhost:7015/Default/Index
Admin Page  =  https://localhost:7015/Dashboard/Index
User Page   =  https://localhost:7015/User/Panel
```

# Used Packages for Project
EntityLayer
```cs
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.25
https://www.nuget.org/packages/Microsoft.AspNetCore.Identity/2.2.0
https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/6.0.0
```

DataAccessLayer
```cs
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/8.0.0
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.25
https://www.nuget.org/packages/Microsoft.AspNetCore.Identity/2.2.0	
https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/6.0.0
```

BusinessLayer
```cs
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/8.0.0
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/6.0.25
- https://www.nuget.org/packages/FluentValidation.AspNetCore/11.3.0
```

CoreProject
```cs
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/8.0.0
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.25
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/6.0.25
- https://www.nuget.org/packages/FluentValidation.AspNetCore/11.3.0
https://www.nuget.org/packages/Microsoft.AspNetCore.Identity/2.2.0	
https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/6.0.0
```

### Migrations
Use this commands for the `Migration Operations` from DataAccessLayer:
- Create Migration
```
    PM> Add-Migration [MigrationName]
```
- Update Data   (Add Configurations)
```
    PM> Update-Database
```
- Remove Last Migration
```
    PM> Remove-Migration
```
- Drop the Database
```
    PM> Drop-Database
```

## Identity Error Solution
```cs

Error :
-
An unhandled exception occurred while processing the request.
InvalidOperationException: Unable to resolve service for type 
'Microsoft.AspNetCore.Identity.UserManager`1[EntityLayer.Concrete.ReUser]' 
while attempting to activate 'CoreProject.Areas.User.Controllers.RegisterController'.
/*---------------------*/
Solution :
- 
Program.cs ::
builder.Services.AddIdentity<ReUser, ReUserRole>()
    .AddEntityFrameworkStores<Context>();
builder.Services.AddDbContext<Context>();

```

[openweathermap Api](https://openweathermap.org/current)