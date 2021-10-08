using Hangfire.Dashboard;
using Prodest.EOuv.Shared.Util;

namespace Prodest.EOuv.Background.Dashboard
{
    public class CustomAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var user = context?.GetHttpContext()?.User;
            var profiles = user.FindFirst("role")?.Value;

            return user != null
                && user.Identity.IsAuthenticated
                && !string.IsNullOrWhiteSpace(profiles)
                && profiles.Contains("Gestor");
        }
    }
}