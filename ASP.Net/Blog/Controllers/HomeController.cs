using Blog.Applications.ArticleService;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult IndexTest([FromServices] IArticleService dataService2)
        {
            IArticleService dataService3 = HttpContext.RequestServices.GetService<IArticleService>();

            return View();
        }


        public IActionResult Index()
        {
            Article article = new Article();
            article.Id = 9999;

            ViewData["AA"] = "aaaa";
            ViewBag.BB = "bbb";

            ViewData["CC"] = article.Id;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HelloWorld()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}