using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Serilogg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            _logger.LogInformation("This is an information Log");
            _logger.LogError("This is an Error Log");
            _logger.LogWarning("This is a Warning Log");

            return Ok();
        }
    }
}
