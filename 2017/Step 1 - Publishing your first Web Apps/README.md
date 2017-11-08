# Goal
For this part of the bootcamp, our attendees will create a shiny new website in Visual Studio. We'll add a form to capture a message submitted by the user. Finally, they'll deploy to Azure App Service so the entire world can marvel at their amazing websites!

# Reference
https://www.asp.net/mvc


# Let's code!
## Open website
Fire up Visual Studio. Click `File -> Open  -> Project/Solution` and navigate to the supplied solution in Step 0.

![img1][img1]

### The Model

In the `/Models` folder, add a new class called `RunnerPerformance.cs`:

```cs
using System;

namespace WebAppAspNetCore.Models
{
    public class RunnerPerformance
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

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

### Enable Scaffolding

Scaffolding is a code generation framework for ASP.NET Web applications. 

Right click on the folder Controllers. Select 'Add -> Controller'. In the dialogbox, click on 'Full Dependencies'.

![img11][img11]

### The Controller

Right click on the folder Controllers. Select 'Add -> Controller'. 

Select 'MVC Controller - Empty'. 

![img11][img11]

In the next window give name "RunnerPerformancesController".

Select all the lines of code in this file, and replace with :

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppAspNetCore.Models;

namespace WebAppAspNetCore.Controllers
{
    public class RunnerPerformancesController : Controller
    {

       
        public IActionResult Index()
        {
            var runnerPerformances = new List<RunnerPerformance>() {
            new RunnerPerformance(){Id = 1, FirstName = "John", LastName = "Smith", FivekmTime = 15},
            new RunnerPerformance(){Id = 2, FirstName = "Kevin", LastName = "Brady", FivekmTime = 10}
            };

            return View(runnerPerformances);
        }
    }
}
```

### The View

Under the `/Views` folder, create a `RunnerPerformances` folder [Add -> New Scaffolded item... -> MVC View]. Add a new view called `Index`. Use the `List` template, and select the model we just created `RunnerPerformance`. Click `Add` and then open the view for editing.

![img10][img10]

The only edit we need to make is to remove the `ActionLink` for Edit, Details and Delete.

```html
       <td>
                @Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) |
                @Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) |
                @Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })
            </td>
```

### The Layout

In file `/Views/Shared/_Layout.cshtml`, under this line of code : '<li><a asp-area="" asp-controller="Home" asp-action="Index">Home</a></li>'

add link to RunnerPerformances section : `<li><a asp-area="" asp-controller="RunnerPerformances" asp-action="Index">RunnerPerformances</a></li>`

### Build and Run!

Hit F5 and PROFIT!!!

## Deploying to Azure

There's no point in building a glorious form like this unless you can show it off. We'll now do a deployment to an Azure App Service.

### Visual Studio Publish

The easiest way to deploy is by having Visual Studio publish it for you. During the course of the publish, you'll be asked for your credentials, and you'll have to fill in some additional deployment details.

Start by right-clicking on the web project and clicking `Publish`. If you haven't logged in with your Microsoft account, you'll be asked for your credentials now. Once you are logged in, you should be presented with this screen:

![img4][img4]

Choose your subscription, and click `New` to setup your App Service:

![img5][img5]

The Web App Name field will be pre-populated with a globally unique name. Unless a Resource Group and App Service Plan have already been created under the subscription, they will need to be added now. Once all the fields have been filled in, click `Create` and our App Service will be provisioned.

Once provisioning is complete, our publishing profile is complete and the Publish dialog will appear to guide us through the rest of the process:

![img6][img6]

At this point we should be able to click Publish, and wait a few minutes for the deploy to complete. We can keep an eye on the Output window to check the status. When the deployment is complete, our browser should open a new tab and display our cloud-powered website!

![img7][img7]

## Check out the portal

Point a browser to https://portal.azure.com. Click on the Hamburger button and select `All resources` from the side menu. The new App Service should show up:

![img8][img8]

Clicking on the App Service will take us to a screen where you can manage and monitor your website.

![img9][img9]

## Addendum

I ran into a couple issues during this deployment. First, stale credentials can prevent subscriptions from appearing when doing a publish. Follow these instruction to remedy: http://stackoverflow.com/questions/24507589/visual-studio-not-finding-my-azure-subscriptions

I also ran into this error during deployment:

```
Warning : Retrying the sync because a socket error (10054) occurred
Retrying operation 'Serialization' on object sitemanifest (sourcePath). Attempt 1 of 10.
```

This issue was resolved by adding an inbound rule to the firewall on port 8172 (TCP)

# End


[img1]: Media/img1.png "New Project"
[img4]: Media/img4.png "Create new App Service"
[img5]: Media/img5.png "Add App Service details"
[img6]: Media/img6.png "Publish website"
[img7]: Media/img7.png "Deployed website in browser"
[img8]: Media/img8.png "Azure Resources screen"
[img9]: Media/img9.png "Web app management screen"
[img10]: Media/img10.png "Add a view"
[img11]: Media/img11.png "Scaffolding"
