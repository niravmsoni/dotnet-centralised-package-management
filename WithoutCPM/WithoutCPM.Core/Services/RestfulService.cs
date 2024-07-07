using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace WithoutCPM.Core.Services
{
    public class RestfulService : IRestfulService
    {
        private readonly ILogger<RestfulService> _logger;

        public RestfulService(ILogger<RestfulService> logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<ResponseObject>> GetObjects()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.restful-api.dev/"),
                Timeout = TimeSpan.FromSeconds(5)
            };

            var sw = Stopwatch.StartNew();
            var response = await httpClient.GetAsync("/objects");
            sw.Stop();

            _logger.LogInformation("Response retrieved from downstream API in {duration} milliseconds", sw.ElapsedMilliseconds);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<ResponseObject>>(json);
        }
    }
}
