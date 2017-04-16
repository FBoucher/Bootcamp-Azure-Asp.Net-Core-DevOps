### Console App to create Message Queue

        static void Main(string[] args)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            var queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            var queue = queueClient.GetQueueReference("my-gab-queue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage("Hello GLobal Azure Bootcamp!");
            queue.AddMessage(message);
        }


### App.config

    <configuration>
        <startup> 
            <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
        </startup>
    <appSettings>
        <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=frankgab2017storage;AccountKey=zBL4XTekj7/oB8RoeBclBr6KUpSx889G8W5MQiqtuW0j9yhWfcu/K+ECy/ShGGJCzWHdGdxlYbgoU6zW9z/ncg==;EndpointSuffix=core.windows.net" />
    </appSettings>
    </configuration>


# Nuget Package Required

    Install-Package Microsoft.WindowsAzure.ConfigurationManager

    Install-Package WindowsAzure.Storage

