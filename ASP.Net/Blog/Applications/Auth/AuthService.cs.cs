using Blog.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Applications.Auth
{
    public class AuthService : IAuthService
    {
        private readonly BlogTestContext _db;

        public AuthService(BlogTestContext db)
        {
            _db = db;
        }

        public async Task<bool> LoginUserCheckPwd(LoginRequest mode)
        {
            try
            {
                var result = await _db.Auths.FirstOrDefaultAsync(x => x.Account == mode.Account);

                if (result == null)
                {
                    return false;
                }
                else
                {
                    return result.Pwd == mode.Pwd;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Register(RegisterRequest mode)
        {
            try
            {
                Models.Auth auth = new Models.Auth();
                auth.Account = mode.Account;
                auth.Pwd = mode.Pwd;

                if (string.IsNullOrEmpty(auth.Account))
                {
                    mode.Msg = "Account Error";

                    return false;
                }
                else if (string.IsNullOrEmpty(auth.Pwd))
                {
                    mode.Msg = "Password Error";
                    return false;
                }

                var result = _db.Auths.FirstOrDefault(x => x.Account == mode.Account);

                if (result != null)
                {
                    mode.Msg = "Account Already Exist";
                    return false;
                }
                else
                {
                    _db.Auths.Add(auth);
                    await _db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<Models.Auth> GetAuthList()
        {
            return _db.Auths.ToList();
        }


        public int TestAdd(int a, int b)
        {
            return a + b;
        }

        public int TestSub(int a, int b)
        {
            return a - b;
        }
    }
}
