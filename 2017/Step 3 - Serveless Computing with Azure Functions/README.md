Goal
======

Create an Azure Function that will be triggered when a new message is added to an Azure storage queue. 
Validate in the debug window that the text for the message is the same as written in the Website textbox.


Reference
=========

- https://docs.microsoft.com/en-us/azure/azure-functions/


Let's code!
===========

Create an Azure Function Domain
-------------------------------

From portal.azure.com, click the big green "+" in the top left corner. Search for "Function", and select **Function App**. Click create button will open a form to specify the information related to your Function App "domainname".

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

- Select the Scenario Data processing
- Select C#
- Click the Create this function button.

![CreateDataFunction][CreateDataFunction]

(Because it's our first function, the portal will do a little tour of the interface)


Configure the Function App
--------------------------

- From the left section, select **Integrate**. 
- Select the Storage account connection used in Step 2.



[SearchFunctionApp]: Media/SearchFunctionApp.png "Search Function App"
[CreateFunctionApp]: Media/CreateFunctionApp.png "Create a Function App"
[CreateDataFunction]: Media/CreateDataFunction.png "Create Data processing Function"