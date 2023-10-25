using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Applications.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly BlogTestContext _db;

        public ArticleService(BlogTestContext db)
        {
            _db = db;
        }

        public async Task CreateArticle(string account, string content)
        {
            try
            {
                Article article = new Article();
                article.Account = account;
                article.Content = content;
                article.Ctime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

                _db.Articles.Add(article);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                return;
            }
        }

        public async Task DeleteArticle(long id)
        {
            try
            {
                var result = (from table in _db.Articles select table).Where(x => x.Id == id).First();

                if (result == null)
                {
                    return;
                }

                _db.Articles.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return;
            }
        }


        public async Task UpdateArticle(Article article)
        {
            try
            {
                var result = _db.Articles.Where(x => x.Id == article.Id).First();

                if (result == null)
                {
                    return;
                }

                article.Account = result.Account;

                result.Content = article.Content;
                result.Ctime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

                _db.Articles.Update(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return;
            }
        }

        public async Task<IList<Article>> GetArticleList()
        {
            return await _db.Articles.ToListAsync();
        }
    }   
}
