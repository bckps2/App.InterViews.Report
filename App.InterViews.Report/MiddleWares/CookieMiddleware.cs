using App.InterViews.Report.CrossCutting.Helper;
using System.Security.Claims;

namespace App.InterViews.Report.MiddleWares
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Cookies.Any())
            {
                var cookieUser = context.Request.Cookies.FirstOrDefault(c => c.Key.Equals("SESSION"));

                var userId = CustomCryptography.Decrypt(cookieUser.Value);
                var identity = context.User.Identity as ClaimsIdentity;
                identity!.AddClaim(new Claim(ClaimTypes.UserData, userId));
            }

            await _next(context);
        }
    }
}
