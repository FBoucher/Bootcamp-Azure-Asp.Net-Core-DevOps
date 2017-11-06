# Goal

Explore the database created by the application. Learn how to connect, explore and see some tools.

## Reference

https://www.asp.net/mvc

# Let's code!

## Use Azure Portal to create Azure SQL Database 

In the Azure portal, click on new and search for "sql database"..

![img1][img1]

Create a Azure SQL Database. In the form, make sure to select the same Resource Group with your Web Application. The name of database must be 'BootCampDB'

![img2][img2]

Create a new Database Server in the Server section. The server name must be unique.

![img3][img3]

### Set server firewall

Before to connect your application to your new Azure SQL Database, you must first set a Firewall.

Microsoft Azure SQL Database provides a relational database service for Azure and other Internet-based applications. To help protect your data, firewalls prevent all access to your database server until you specify which computers have permission. The firewall grants access to databases based on the originating IP address of each request.

For setting the firewall, click on 'SQL Databases', select your database in the list. Click on 'Set server firewal'

![img4][img4]

Click on 'Add client IP' to allow access to Azure services at your client IP address and click on 'Save'. 

![img5][img5]

Close the 'Firewall settings' Windows.

### ConnectionString

Click on 'show database connection strings'  

![img6][img6]

Copy the connectionstring.

![img7][img7]

Fire up Visual Studio. Click `File -> Open  -> Project/Solution` and navigate to the supplied solution in Step 0.

Edit appsettings.json and add new parameter with the name 'AzureDBConnectionStrings' and paste your Azure connectionstring :

```json
   "AzureDBConnectionStrings": "Server=tcp:bootcampdb.database.windows.net,1433;Initial Catalog=BootcampDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
```

You must replace '{your_username}' with username of your Azure SQL Database and '{your_password}' with password of your Database.

The complet code of appsettings.json file should look like :

```json

{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "ConnectionStrings": {
    "LocalDBConnectionStrings": "Server=(localdb)\\mssqllocaldb;Database=BootCampDB;Trusted_Connection=True;MultipleActiveResultSets=true",
    "AzureDBConnectionStrings": "Server=tcp:bootcampdb.database.windows.net,1433;Initial Catalog=BootcampDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
```

Edit the Startup.cs file. Change the name of the connectionString parameter to get Azure SQL Database ConnectionString.

```cs
Configuration.GetConnectionString("AzureDBConnectionStrings")
```

### Use Migrations to initialise your Database

You can use Entity Framework Core Migrations to create 'RunnerPerformances' and 'Statistics' tables in your Azure SQL Database.

To do it, open 'Package Manager Console' (Click `Tools -> Nuget Package Manager  -> Package Manager Console`) and execute the following command.

Update-Database

### Test your application locally

Hit F5 for run your application and test your access to Azure SQL Database.

### Deploy your application

Right-click on the web project and click on `Publish`. Select 'Microsoft Azure App Service', click on 'Select Existing'. After that click on 'Publish'.

![img8][img8]

In the next Windows, select your Subscription and your Azure App Service.

![img9][img9]

Click Ok and wait a few minutes for the deploy to complete. We can keep an eye on the Output window to check the status. When the deployment is complete, our browser should open a new tab and display our cloud-powered website!


## End

[img1]: Media/img1.png 
[img2]: Media/img2.png 
[img3]: Media/img3.png 
[img4]: Media/img4.png 
[img5]: Media/img5.png 
[img6]: Media/img6.png 
[img7]: Media/img7.png 
[img8]: Media/img8.png 
[img9]: Media/img9.png 