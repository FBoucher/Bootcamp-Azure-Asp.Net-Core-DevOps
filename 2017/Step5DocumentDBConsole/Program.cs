using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DocumentDBTestConsole
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static string dbId = "cognitivedb";
        static Uri dbUri = new Uri($"dbs/{dbId}", UriKind.Relative);
        static string collectionId = "sentiment";
        static Uri collectionUri = new Uri($"dbs/{dbId}/colls/{collectionId}", UriKind.Relative);

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            Uri docAccountUri = new Uri(Configuration["DocumentDBUri"]);
            DocumentClient docClient = new DocumentClient(docAccountUri, Configuration["DocumentDBKey"]);

            var db = await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = dbId });
            await docClient.CreateDocumentCollectionIfNotExistsAsync(dbUri,
                new DocumentCollection
                {
                    Id = collectionId,
                    PartitionKey = new PartitionKeyDefinition
                    {
                        Paths = { "/userId" },
                    },
                });

            var exampleText = "I feel great!";
            var exampleResponse = File.ReadAllText("SentimentAnalysisResponse.json");
            dynamic parsedResponse = JObject.Parse(exampleResponse);

            var analyzedMessage = new AnalyzedMessage
            {
                message = exampleText,
                sentimentScore = parsedResponse.documents[0].score,
                userId = Guid.NewGuid().ToString()
            };
            var response = await docClient.CreateDocumentAsync(collectionUri, analyzedMessage);
        }
    }
}
