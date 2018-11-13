using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using NooBIT.AspNetCore.Mvc.Http;
using System;

namespace NooBIT.AspNetCore.Mvc.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRecommendedSecurityHeaders(this IApplicationBuilder app, IHostingEnvironment environment) 
            => app.UseCustomHeaders(new HeaderPolicyBuilder().AddRecommendedSecurityHeaders(environment));

        public static IApplicationBuilder UseCustomHeaders(this IApplicationBuilder app, HeaderPolicyBuilder builder) 
            => app.UseMiddleware<HeaderMiddleware>(builder.Build());

        public static IApplicationBuilder UseStaticFilesWithCaching(this IApplicationBuilder app, TimeSpan cacheDuration) 
            => app.UseStaticFiles(new StaticFileOptions
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