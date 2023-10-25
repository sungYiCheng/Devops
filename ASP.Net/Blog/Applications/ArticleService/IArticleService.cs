using Blog.Models;

namespace Blog.Applications.ArticleService
{
    public interface IArticleService
    {
        Task CreateArticle(string account, string content);

        Task DeleteArticle(long id);

        Task UpdateArticle(Article model);

        Task<IList<Article>> GetArticleList();
    }
}
