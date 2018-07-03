using Microsoft.AspNetCore.Builder;
using NooBIT.Web.Middlewares;
using NooBIT.Web.Security;

namespace NooBIT.Web
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRecommendedSecurityHeaders(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomHeaderMiddleware>(new CustomHeaderPolicyBuilder().AddRecommendedSecurityHeaders());
        }

        public static IApplicationBuilder UseCustomHeaders(this IApplicationBuilder app, CustomHeaderPolicyBuilder builder)
        {
            return app.UseMiddleware<CustomHeaderMiddleware>(builder.Build());
        }
    }
}