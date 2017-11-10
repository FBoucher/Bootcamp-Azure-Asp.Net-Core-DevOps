# Goal

In this last step of this bootcamp, we will explore Visual Studio Team Services (VSTS) and learn how we can deploy directly from it.

## Let's Get Started

First, we need an account. Navigate with your favorite browser to https://www.visualstudio.com/team-services/ and click on the `Get started for free >` button.  Use the same credential as you are using for the Azure.portal.com. After few minutes, you should see your greetings in VSTS.

## Create a Project

Create a new Project called BootCamp by clicking the New Project Button. Give it a short description and leave the other option by default, click the Create button.

![CreateProject][CreateProject]

### Get Some Code

As soon as the project is created you have many different options. In this example, we will keep it simple and import the code from another Github repository. Click on the Import button and enter this url: `https://github.com/FBoucher/AzureBootcampAspNetCoreSample.git`. After the import is completed you should have something like this.

![TheCodeIsIn][TheCodeIsIn]

### Let's Explore a bit

It's a good idea now to take some time and explore VSTS. 

### Create a deployment

In the next step, we will configure VSTS to start automatically a build and a deployment when some changes are pushed to the repository.

From the top menu, select *Build and Release*, then click the blue button *+ New Definition*.

![NewDefenition][NewDefenition]

A lot of different template are available, since our application is a Asp.Net Core, select that one from the list and click *Apply*.

![SelectTemplate][SelectTemplate]

For the bootcamp our Build process will also be deploying our solution in Azure. Let's Add another Task. Click on the "+" sign and select Azure App Service Deploy.

![AddTaskDeploy][AddTaskDeploy]

### Configuration Time

Next we need to configure our deployment. On this **Azure App Service Deploy:** task, select your subscription (you will probably need some authorization), the App Service Name you deployed earlier. Set the Package folder to `$(build.artifactstagingdirectory)\WebApp.zip`. This value can be found in the **Build solution** task.

> **Note**
> Be sure to select **Hosted VS2017** as build Agent in the **Phase 1** task.

Then go to the Triggers Tab, and enable the trigger of the Continuous Integration. This will fire our build definition when some code is pushed to our VSTS repository.

![EnableTrigger][EnableTrigger]

When you are done, click on the *Save & Queue*.  A build agent should start building your solution.  If everything works correctly, you  **Build succeeded**.

## Testing time

Navigate in your freshly deployed application.  If you are not sure of the URL, go to portal.azure.com. Once in the application, navigate to the About page. Now let's fix this.

VSTS contains a very good editor so let fix this online. As an option, you could clone the repository to your PC fix the code from there and push it back to VSTS.

 ![CloneCode][CloneCode]

In our case, we will fix it online. Navigate to the code in find the `HomeController.cs` file. Edit the file to fix the Error. Once you are done, Commit your work and add a comment.  This should trigger our build, and after few minutes, you should have your fix live in Azure.

## End

[CreateProject]: Media/CreateProject.png "Creating a new Project"
[TheCodeIsIn]: Media/TheCodeIsIn.png "The Code Is In"
[NewDefenition]: Media/NewDefenition.png "New Defenition"
[SelectTemplate]: Media/SelectTemplate.png "Select the template"
[AddTaskDeploy]: Media/AddTaskDeploy.png "Add Task to Deploy"
[EnableTrigger]: Media/EnableTrigger.png "Enable Trigger"
[CloneCode]: Media/CloneCode.png "Clone Code"

