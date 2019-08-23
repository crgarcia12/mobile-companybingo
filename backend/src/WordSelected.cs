using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace src
{
    public static class ElementSelected
    {
        [FunctionName("WordSelected")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string word = req.Query["word"];
            log.LogInformation($"C# HTTP trigger function processed a request. {word}");

            return String.IsNullOrWhiteSpace(word) 
                ? new BadRequestObjectResult("Please pass a name on the query string or in the request body");
                : (ActionResult)new OkObjectResult($"Hello, {word}")
        }
    }
}
