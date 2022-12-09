using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace func
{
    public static class Echo
    {
        [FunctionName("Echo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger("POST")] HttpRequest req, ILogger log)
        {
            log.LogInformation($"C# HTTP trigger Echo function processed a request at {DateTime.Now.ToString()}.");

             return new OkObjectResult(req.Body);
        }
    }
}
