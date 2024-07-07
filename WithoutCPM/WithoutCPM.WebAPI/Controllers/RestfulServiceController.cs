using WithoutCPM.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WithoutCPM.Core.Services;

namespace WithoutCPM.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RestfulServiceController : ControllerBase
    {
        private readonly ILogger<RestfulServiceController> _logger;
        private readonly IRestfulService _restfulService;

        public RestfulServiceController(ILogger<RestfulServiceController> logger,
            IRestfulService restfulService)
        {
            _logger = logger;
            _restfulService = restfulService;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseObject>> Get()
        {
            var sw = Stopwatch.StartNew();
            var response = await _restfulService.GetObjects();
            sw.Stop();
            _logger.LogInformation("Response retrieved in {duration} milliseconds", sw.ElapsedMilliseconds);
            return response;
        }
    }
}
