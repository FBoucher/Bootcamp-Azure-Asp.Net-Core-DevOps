# Goal

In this last step of this bootcamp, we will explore Visual Studio Team Services (VSTS) and learn how we can deploy directly from it.

## Let's Get Started

First we need an account. Navigate with your favorite browser to https://www.visualstudio.com/team-services/ and click on the `Get started for free >` button.  Use the same credential as you are using for the Azure.portal.com. After few minutes you should see your greetings in VSTS.

## Create a Project

Create a new Project called BootCamp by clicking the New Project Button. Give it a short description and leave the other option by default, click the Create button.

![CreateProject][CreateProject]

### Get Some Code

As soon as the project is created you have many different options. In this exemple we will keep it simpe and import the code from another Github repository. Click on the Import button and enter this url: `https://github.com/FBoucher/AzureBootcampAspNetCoreSample.git`. After the import is completed you should have something like this.

![TheCodeIsIn][TheCodeIsIn]

### Let's Explore a bit

It's a good idea now to take some time and explore VSTS. 

### Create a deployment

In the next step we will configure VSTS to start automaticaly a build and a deployment when some changes are push to the repository

From the top menu, select **Build and Release**, then click the blue button **+ New Definition**.

![NewDefenition][NewDefenition]

A lot of different template are available, since our application is a Asp.Net Core, select that one from the list and click **Apply**.

![SelectTemplate][SelectTemplate]

For the bootcamp our Build process will also be deploying our solution in Azure. Let's Add another Task. Click on the "+" sign and select Azure App Service Deploy.

![AddTaskDeploy][AddTaskDeploy]

### COnfiguration of the Build

[CreateProject]: Media/CreateProject.png "Creating a new Project"
[TheCodeIsIn]: Media/TheCodeIsIn.png "The Code Is In"
[NewDefenition]: Media/NewDefenition.png "New Defenition"
[SelectTemplate]: Media/SelectTemplate.png "Select the template"
[AddTaskDeploy]: Media/AddTaskDeploy.png "Add Task to Deploy"
