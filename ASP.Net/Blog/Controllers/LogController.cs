using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class LogController : Controller
    {

        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"Test Log: 123");

            _logger.LogDebug(10, "Test Debug");
            _logger.LogInformation(11, "Test Information");
            _logger.LogWarning(12, "Test Warning");
            _logger.LogError(13, "Test Error");
            _logger.LogCritical(14, "Test Critical");


            return Redirect("/");
        }
    }
}
