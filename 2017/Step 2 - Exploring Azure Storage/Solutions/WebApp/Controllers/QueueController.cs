using System.Web.Mvc;
using WebApp.Models;

using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types
using Newtonsoft.Json;

namespace WebApp.Controllers
{
	public class QueueController : Controller
	{
		// GET: Queue/CreateMessage
		public ActionResult CreateMessage()
		{
			return View();
		}

		// POST: Queue/CreateMessage
		// Reference : https://docs.microsoft.com/en-us/azure/storage/storage-dotnet-how-to-use-queues
		[HttpPost]
		public ActionResult CreateMessage(QueueMessageModel message)
		{
			if (ModelState.IsValid)
			{
				// Retrieve storage account from connection string.
				CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
					CloudConfigurationManager.GetSetting("StorageConnectionString"));

				// Create the queue client.
				CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

				// Retrieve a reference to a container.
				CloudQueue queue = queueClient.GetQueueReference("myqueue");

				// Create the queue if it doesn't already exist
				queue.CreateIfNotExists();

				var messageAsJson = JsonConvert.SerializeObject(message);
				var cloudQueueMessage = new CloudQueueMessage(messageAsJson);

				// Create a message and add it to the queue.
				queue.AddMessage(cloudQueueMessage);

				return RedirectToAction("Index", "Home");
			}

			return View(message);
		}
	}
}
