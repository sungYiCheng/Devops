using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blog.Middlewares
{
    public class ReqHeaderChecker
    {
        private readonly RequestDelegate _next;

        public ReqHeaderChecker(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // 取得HTTP Request內的Headers
            var headers = context.Request.Headers;

            // 取得特定Header的內容
            string header = headers["TEST"].ToString();

            // 檢查Header的內容
           // if (!header.Equals(@"12345"))
          //  {
           //     throw new Exception("Header Error!");
           // }

            // 將Request繼續往下送
            await _next.Invoke(context);
        }
    }
}
