using App.InterViews.Report.CrossCutting.Helper;
using System.Security.Claims;

namespace App.InterViews.Report.MiddleWares;

public class TokenDecryptMiddleware
{
    private readonly RequestDelegate _next;

    public TokenDecryptMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated && context.User.HasClaim(c => c.Type == ClaimTypes.Role))
        {
            var encryptedRole = context.User.FindFirst(ClaimTypes.Role);
            
            if (encryptedRole != null)
            {
                var decryptedRole = CustomCryptography.Decrypt(encryptedRole.Value);
                var identity = context.User.Identity as ClaimsIdentity;
                identity!.AddClaim(new Claim(ClaimTypes.Role, decryptedRole));
            }
        }

        await _next(context);
    }
}
