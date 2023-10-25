namespace Blog.Models
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Account { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime Time { get; set; }
    }

    public class ArticleViewAdd    {

        public List<ArticleViewModel> ArticleList{ get; set; }

        public string Account { get; set; }
    }
}
