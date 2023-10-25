using Blog.Applications.ArticleService;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _article;

        public ArticleController(IArticleService articleService)
        {
            _article = articleService;
        }

        [HttpGet("Article")]
        public async Task<IActionResult> Index([FromQuery] string account)
        { 
            var model = await _article.GetArticleList();
            var result = new List<ArticleViewModel>();
            ArticleViewAdd articleViewAdd = new ArticleViewAdd();

            if (model is not null && model.Count > 0)
            {
                result = model.Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    Account = x.Account,
                    Time = DateTimeOffset.FromUnixTimeSeconds(x.Ctime).LocalDateTime,
                }).ToList();

                articleViewAdd.ArticleList = result;
                articleViewAdd.Account = account;
            }

            return View(articleViewAdd);
        }

        [HttpPost("Article")]
        public async Task<IActionResult> CreateArticle(string Content, [FromQuery] string account)
        {
            await _article.CreateArticle(account, Content);

            return RedirectToAction("index", routeValues: new { account = account });
        }

        [HttpPost("Article/Delete")]
        public async Task<IActionResult> Delete(long id, [FromQuery] string account)
        {
            await _article.DeleteArticle(id);

            return RedirectToAction("index", routeValues: new { account = account });
        }

        [HttpGet("Article/Update")]
        public async Task<IActionResult> Update(int id)
        {
            Article article = new Article();
            article.Id = id;

            return View(article);
        }

        [HttpPost("Article/Update")]
        public async Task<IActionResult> Update(Article article)
        {
            await _article.UpdateArticle(article);

            return RedirectToAction("index", routeValues: new { account = article.Account });
        }
    }
}
