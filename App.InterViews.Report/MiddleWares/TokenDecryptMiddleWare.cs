using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace App.InterViews.Report.MiddleWares;

public class TokenDecryptMiddleWare
{
    private readonly RequestDelegate _next;

    public TokenDecryptMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated && context.User.HasClaim(c => c.Type == ClaimTypes.Role))
        {
            var encryptedRole = context.User.FindFirst(ClaimTypes.Role).Value;

            var decryptedRole = Decrypt(encryptedRole);

            var identity = context.User.Identity as ClaimsIdentity;
            identity!.AddClaim(new Claim(ClaimTypes.Role, decryptedRole));
        }

        await _next(context);
    }

    static string Decrypt(string encryptedText)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] keySecret = Encoding.ASCII.GetBytes("your_secret_key_hereyour_secret_");
        byte[] iv = Encoding.ASCII.GetBytes("your_secret_key_");

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = keySecret;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;
            aesAlg.IV = iv;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecrypt = new MemoryStream(encryptedBytes))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
