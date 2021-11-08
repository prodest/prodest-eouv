using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace Prodest.EOuv.Shared.Utils
{
    public static class CookieEvents
    {
        public static Task DontRedirectApiRequestToForbidden(RedirectContext<CookieAuthenticationOptions> ctx)
        {
            if (ctx.Request.Path.StartsWithSegments("/api"))
            {
                ctx.Response.StatusCode = 403;
            }
            else
            {
                ctx.Response.Redirect(ctx.RedirectUri);
            }

            return Task.CompletedTask;
        }
    }
}
