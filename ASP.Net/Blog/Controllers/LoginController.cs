using Blog.Applications.Auth;
using Blog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public LoginController(IAuthService auth, IConfiguration configuration)
        {
            _authService = auth;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       
        #region cookie 驗證登入
        [HttpPost]

        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (await _authService.LoginUserCheckPwd(request))
            {
                var claims = new List<Claim>
                {
                    new Claim("UserAccount", request.Account),
                   // new Claim(ClaimTypes.Role, "Administrator")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties 
                    { 
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),
                        IsPersistent = true,
                    }
                );

                return RedirectToAction(actionName: "index", controllerName: "Article", routeValues: new { account = request.Account });
            }

            request.Msg = "Login Error";

            return View(request);
        }
        #endregion

        #region JWT 驗證登入
        [HttpPost]

        public async Task<string> IndexJWT(LoginRequest request)
        {
            if (await _authService.LoginUserCheckPwd(request))
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Email, "squalllucky@gmail.com"),
                    new Claim(JwtRegisteredClaimNames.NameId, "5566"),
                    new Claim("UserAccount", request.Account),
                   // new Claim(ClaimTypes.Role, "Administrator")
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:KEY"]));

                var jwt = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                return token;
            }

            return "Login Error";
        }
        #endregion

        [Route("api/Logout")]
        public IActionResult logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(actionName: "Index", controllerName: "Login");
        }

        public IActionResult NoLogin()
        {
            return View();
        }
    }
}
