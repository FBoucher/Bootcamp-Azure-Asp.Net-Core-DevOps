Goal
======

Create an Azure Function that will be executed every 5 minutes to calculate the average to the time saved in the database and saving back the result. Validate in the debug window that the text for the message is the same as written in the Website textbox.

Reference
=========

- https://docs.microsoft.com/en-us/azure/azure-functions/

Let's code!
===========

Create an Azure Function Domain
-------------------------------

From portal.azure.com, click the big green "+" in the top left corner. Search for "Function", and select **Function App**. Click the create button will open a form to specify the information related to your Function App "domainname".

![SearchFunctionApp][SearchFunctionApp]

- App Name: That the name of the domain, where all your functions will be regrouped. This name must be unique through the web.
- Subscription: The subscription where the Function App will be.
- Ressource Group: Select the same Ressource Group used for the previous components.
- Hosting plan: Select Consomption Plan.
- Location: Select the same location used for the previous components.
- Create a new Storage Account. Give it a name like [yourname]functions

![CreateFunctionApp][CreateFunctionApp]

Click the create button.

Create The Data processing Azure Function
-----------------------------------------

1. Click the "+" sign to add a new Function App.
1. Select the Scenario Data processing
1. Select C#
1. Click the *Create this function* button.

![CreateDataFunction][CreateDataFunction]

(Because it's our first function, the portal will do a little tour of the interface)

Configure the Function App
--------------------------

1. From the left section, select your Function Apps.
1. Click on the *Platform features* tab on the top of the screen.
1. Click on Application settings under the GENERAL SETTINGS section.
1. Scroll to the section **Connection strings** and click on *+ Add new connection string*.
1. Set the name to something like sqlConn and the value to the connectiontring identified previously.
1. Don't forget to scroll back up to click the save button.

![ShowApplicationSettings][ShowApplicationSettings]

Test the Function App
--------------------------

Now let's calculate some statistics. Copy-Paste the code from the snippet `function_TimeTrigger_final.txt` inside your function.

The `#r` command are to add references to library we need that are already available in Azure. Save your changes.

Clear the Logs windows by clicking the Clear button, and go back save another comment in the WebApp. You should have something similar to that.

![Result][Result]

Bonus
=====

Try to do the same thing from a Visual Studio Function Project.

![NewProject][NewProject]

Then to add a new Function, right mouse click on the project node in Solution Explorer, then choose Add > New Item. Choose Azure Function from the dialog box.

![AddFunction][AddFunction]

Select the type of function you need...

One all the code is in place hit F5 to run it locally.

![DebugMode][DebugMode]

[SearchFunctionApp]: Media/SearchFunctionApp.png "Search Function App"
[CreateFunctionApp]: Media/CreateFunctionApp.png "Create a Function App"
[CreateDataFunction]: Media/CreateDataFunction.png "Create Data processing Function"
[ShowApplicationSettings]: Media/ShowApplicationSettings.png "Set Queue Storage"
[Result]: Media/Result.png "See Logs"
[connectionstring]: Media/connectionstring.png "Connectionstring available in the portal"
[NewProject]: Media/NewProject.png "Create a new Function Type Project"
[AddFunction]: Media/AddFunction.png "Add a new Function"
[DebugMode]: Media/DebugMode.png "Run the project in Debug"