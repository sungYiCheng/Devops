using Blog.Applications.ArticleService;
using Blog.Applications.Auth;
using Blog.Middlewares;
using Blog.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IAuthService, AuthService>();
//builder.Services.AddTransient<IArticleService, TestService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BlogTestContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("BlogTestDatabase")));

// cookie ����
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    //���n�J�ɷ|�۰ʾɨ�o�Ӻ��}
    option.LoginPath = new PathString("/Login/NoLogin");
});


#region JWT ����
/*
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetConnectionString("Jwt:Issuer"),
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetConnectionString("Jwt:Audience"),
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetConnectionString("JWT:KEY")))
        };
    });
*/
#endregion

// ���[�W����
builder.Services.AddMvc(options =>
{
   options.Filters.Add(new AuthorizeFilter());
});


// for test
var test = builder.Configuration.GetValue<string>("Logging:LogLevel:Default");

var app = builder.Build();

app.UseMiddleware<ReqHeaderChecker>();
app.UseMiddleware<ExceptionMiddleware>();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 
// cookie���ҡA���ǭn�@��
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
