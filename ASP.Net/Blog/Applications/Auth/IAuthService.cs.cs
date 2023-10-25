using Blog.Models;

namespace Blog.Applications.Auth
{
    public interface IAuthService
    {
        Task<bool> LoginUserCheckPwd(LoginRequest mode);

        Task<bool> Register(RegisterRequest mode);
    }
}
