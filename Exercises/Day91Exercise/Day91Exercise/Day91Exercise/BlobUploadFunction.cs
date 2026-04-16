using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Day91Exercise;

public class BlobUploadFunction
{
    private readonly ILogger _logger;

    public BlobUploadFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<BlobUploadFunction>();
    }

    [Function("BlobUploadFunction")]
    public async Task Run(
        [BlobTrigger("uploads/{name}", Connection = "AzureWebJobsStorage")] Stream blob,
        string name)
    {
        _logger.LogInformation($"Blob detected: {name}");

        var logicAppUrl = "https://prod-26.malaysiawest.logic.azure.com:443/workflows/4f42465a06834fc9b833ef78e9092746/triggers/When_an_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_an_HTTP_request_is_received%2Frun&sv=1.0&sig=hKrtZuCV-WtK8NZt7HkYdR1tXkYHumPvrOmblm_INNU";

        using var client = new HttpClient();

        var json = $"{{ \"fileName\": \"{name}\" }}";

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync(logicAppUrl, content);
    }
}






