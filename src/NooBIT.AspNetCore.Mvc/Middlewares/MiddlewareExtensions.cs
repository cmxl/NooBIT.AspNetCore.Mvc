using System;
using Microsoft.AspNetCore.Builder;
using NooBIT.AspNetCore.Mvc.Http;

namespace NooBIT.AspNetCore.Mvc.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRecommendedSecurityHeaders(this IApplicationBuilder app)
        {
            return app.UseCustomHeaders(new HeaderPolicyBuilder().AddRecommendedSecurityHeaders());
        }

        public static IApplicationBuilder UseCustomHeaders(this IApplicationBuilder app, HeaderPolicyBuilder builder)
        {
            return app.UseMiddleware<HeaderMiddleware>(builder.Build());
        }

        public static IApplicationBuilder UseStaticFilesWithCaching(this IApplicationBuilder app, TimeSpan cacheDuration)
        {
            return app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Remove(Header.Server.Name);
                    context.Context.Response.Headers.Add(Header.CacheControl.Name, $"public, max-age={cacheDuration.TotalSeconds}");

                    var expiresDate = DateTime.UtcNow + cacheDuration;
                    var expires = expiresDate.ToString("r");
                    context.Context.Response.Headers.Add(Header.Expires.Name, expires);
                }
            });
        }
    }
}