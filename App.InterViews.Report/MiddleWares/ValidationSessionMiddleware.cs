using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using System.Security.Claims;

namespace App.InterViews.Report.MiddleWares;

public class ValidationSessionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationSessionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext _httpContext, IUserAccountService _userAccountService)
    {
        var isValidUser = false;

        if (_httpContext.Request.Cookies.Any())
        {
            var cookieSession = _httpContext.Request.Cookies["SESSION"];

            if (cookieSession != null && Guid.TryParse(CustomCryptography.Decrypt(cookieSession), out Guid userGuid))
            {
                var userAccount = await _userAccountService.GetByIdAsync(userGuid);

                if (userAccount.IsSuccess)
                {
                    var email = GetEmaiContext(_httpContext);
                    isValidUser = userAccount.Value.Email.Equals(email);
                }
            }
        }

        if (!isValidUser)
        {
            _httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await _httpContext.Response.WriteAsync("Invalid Login.");
        }

        await _next(_httpContext);
    }

    private static string GetEmaiContext(HttpContext _httpContext)
    {
        if (_httpContext.User.Identity.IsAuthenticated && _httpContext.User.HasClaim(c => c.Type == ClaimTypes.Role))
        {
            var encryptedEmail = _httpContext.User.FindFirst(ClaimTypes.Email);

            if (encryptedEmail != null)
            {
                return CustomCryptography.Decrypt(encryptedEmail.Value);
            }
        }

        return string.Empty;
    }
}
