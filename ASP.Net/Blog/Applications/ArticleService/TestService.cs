using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Applications.ArticleService
{
    public class TestService : IArticleService
    {
        readonly string openDataApiUrl;
        private readonly BlogTestContext _db;
        public TestService(IConfiguration configuration, BlogTestContext db)
        {
            openDataApiUrl = configuration.GetValue<string>("TestApiUrl");
            _db = db;
        }

        public Task CreateArticle(string account, string content) { return null; }

        public Task DeleteArticle(long id) { return null; }

        public Task UpdateArticle(Article model) { return null; }

        public Task<IList<Article>> GetArticleList() { return null; }
    }   
}
