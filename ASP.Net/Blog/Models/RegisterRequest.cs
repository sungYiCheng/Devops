namespace Blog.Models
{
    public class RegisterRequest
    {
        public string Account { get; set; } = string.Empty;
        public string Pwd { get; set; } = string.Empty;
        public string Msg { get; set; } = string.Empty;
    }
}
