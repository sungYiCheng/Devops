using Blog.Applications.Auth;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IAuthService _authService;

        public RegisterController(IAuthService auth)
        {
            _authService = auth;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterRequest model)
        {
            if (await _authService.Register(model))
            {
                return Redirect("Login");
            }

            return View(model);
        }
    }
}
