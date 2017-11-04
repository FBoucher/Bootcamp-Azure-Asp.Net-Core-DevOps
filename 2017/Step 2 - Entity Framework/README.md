# Goal

For this part of the bootcamp, our attendees will create a shiny new website in Visual Studio. We'll add the forms to made CRUD operations with Entity Framework Core.

## Reference

https://www.asp.net/mvc

# Let's code!

## Open the website

Fire up Visual Studio. Click `File -> Open  -> Project/Solution` and navigate to the supplied solution in Step 0.

![img1][img1]

### The Model

In the `/Models` folder, add a new class called `RunnerPerformance.cs`:

```cs

using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetCore.Models
{
    public class RunnerPerformance
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name= "Time performed by the runner")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int FivekmTime { get; set; }

    }
}

```

Add another new class called 'Statistic.cs'

```cs

using System;

namespace WebAppAspNetCore.Models
{
    public class Statistic
    {
        public int BestTime { get; set; }

        public int AverageTime { get; set; }
    }
}

```

### The DBContext

In the `/Models` folder, add a new class called `BootCampContext.cs`:

```cs

using System;
using Microsoft.EntityFrameworkCore;


namespace WebAppAspNetCore.Models
{
    public class BootCampContext : DbContext
    {

        
            public BootCampContext(DbContextOptions<BootCampContext> options)
                    : base(options)
            {
            }

            public DbSet<RunnerPerformance> RunnerPerformances { get; set; }

           public DbSet<Statistic> Statistics { get; set; }

    }
}

```

### The ConnectionString

Edit appsettings.json and add ConnectionString

```json

{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "ConnectionStrings": {
    "LocalDBConnectionStrings": "Server=(localdb)\\mssqllocaldb;Database=BootCampDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

```

### Register the context with dependency injection

Edit Startup.cs file  and add update the ConfigureServices method.

```cs

  public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<BootCampContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("LocalDBConnectionStrings")));
        }

```

You need to add this references

```cs

using WebAppAspNetCore.Models;
using Microsoft.EntityFrameworkCore;

```

### Use Migrations to create and update database

Click `Tools -> Nuget Package Manager  -> Package Manager Console` 

![img2][img2]

Enter the following command: `Add-Migration InitialMigration`. The folder Migrations will be created in the root folder of your application.

![img3][img3]

Enter the following command to update the database

Update-Database

### Enable Scaffolding

Right clic on the folder Controllers. Select 'Add -> Controller'. In the dialogbox, clic on 'Full Dependencies'.

![img4][img4]

### CRUD With Entity Framework Core

Right clic on the folder Controllers. Select 'Add -> Controller'.

Select 'MVC Controller with views, using Entity Framework'

![img5][img5]

In the 'Add Controller' window, fill in information.

Model Class : RunnerPerformance

Data context class : BootCampContext

![img6][img6]


### The Layout

In file `/Views/Shared/_Layout.cshtml`, uncomment the Create Message link. The line should  look like this:

`<li>@Html.ActionLink("Create message", "CreateMessage", "Queue")</li>`

### Build and Run!

Hit F5 and PROFIT!!!

## End

[img1]: Media/img1.png "New Project"
[img2]: Media/img2.png "Create new App Service"
[img3]: Media/img3.png "Add App Service details"
[img4]: Media/img4.png "Publish website"
[img5]: Media/img5.png "Deployed website in browser"
[img6]: Media/img6.png "Azure Resources screen"