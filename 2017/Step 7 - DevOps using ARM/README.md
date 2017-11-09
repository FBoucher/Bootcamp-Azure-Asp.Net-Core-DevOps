# Goal
Automate the creation of the resources required by the application in Azure using Infrastructure as Code (IaC) using Visual Studio Resource Group project. For doing that, we'll start from an empty resource group template project in Visual Studio and add to it to cover all the Azure resources found in the previous steps.

# Requirements
* Azure PowerShell v3.7.0 or later. Get it [here](https://github.com/Azure/azure-powershell/releases/tag/v3.7.0-March2017).

# Reference
* https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview
* https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-manager-create-first-template
* https://docs.microsoft.com/en-us/azure/azure-resource-manager/vs-azure-tools-resource-groups-deployment-projects-create-deploy
* https://docs.microsoft.com/en-us/cli/azure/
* https://docs.microsoft.com/en-us/powershell/azure/overview

# Let's code!
## Login in to Azure and select the right subscription
0. Ask the attendees to log into Azure and select the right Azure Subscription

    0. Open a PowerShell window
    0. Change the directory to the DevOps step directory. `cd '{RepositoryPath}\2017\Step 7 - DevOps using ARM'`
    0. Login-AzureRmAccount
    0. Select-AzureRmSubscription -SubscriptionName '{SubscriptionName}'

## Add web application
0. Ask the attendees to open the file 1.json in the *Code Snippets folder*. Copy an paste the code from the `templateFile` members (variables, resources) into `Solutions\Deployment\azuredeploy.json`.
0. Ask to save template file and call `& '.\Solutions\Deployment\Deploy-AzureResourceGroup.ps1' -ResourceGroupLocation 'East US 2'`

## Add Application Insights 
0. Ask the attendees to open the file 2.json in the *Code Snippets folder*. Copy an paste the code from the `templateFile` members (variables, resources) into `Solutions\Deployment\azuredeploy.json`.

    **!! Take great care of replacing the whole `WebApp` resource with the new snippet content.**

0. Ask to save template file and call `& '.\Solutions\Deployment\Deploy-AzureResourceGroup.ps1' -ResourceGroupLocation 'East US 2'`

# Bonus

- In the Azure portal, check out the Azure resources you just deployed and verify the **Deployments** blade of your resource group
- In Visual Studio, use the **JSON Outline** View to edit an ARM Template --> graphical editor.
- In the Azure portal, go to your resource group just deployed and click on the **Locks** blade. Here add a `DoNotDelete` lock (**Lock type** = `Delete`). It's one of the good practice to protect your Azure resources, especially for Production. Don't forget you could automate this by PowerShell for example ;)

# End