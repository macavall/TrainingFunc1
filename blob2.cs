using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace func1;

public class blob2
{
    private readonly ILogger<blob2> _logger;

    public blob2(ILogger<blob2> logger)
    {
        _logger = logger;
    }

    [Function(nameof(blob2))]
    public async Task Run([BlobTrigger("container1/{name}")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}", name, content);
    }
}