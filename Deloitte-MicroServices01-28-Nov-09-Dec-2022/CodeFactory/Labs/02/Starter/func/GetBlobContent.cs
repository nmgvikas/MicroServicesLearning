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
    public static class GetBlobContent
    {
        [FunctionName("GetBlobContent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger("GET")] HttpRequest req, [Blob("content/settings.json")] string jsonContent)
        {
            

            return new OkObjectResult(jsonContent);
        }
    }
}
