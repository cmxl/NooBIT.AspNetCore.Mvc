using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NooBIT.AspNetCore.Mvc.Middlewares;

namespace NooBIT.AspNetCore.Mvc.Optimization
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWebOptimizations(this IApplicationBuilder app, IWebOptimization webOptimization)
        {
            app.UseWebOptimizer(webOptimization.Environment);
            app.UseStaticFilesWithCaching(webOptimization.CacheDuration);
            app.UseResponseCaching();
            app.UseResponseCompression();
            return app;
        }

        public static IServiceCollection AddWebOptimizations(this IServiceCollection services, IWebOptimization webOptimization)
        {
            services.AddWebOptimizer(webOptimization.ConfigurePipeline);
            services.AddResponseCompression(webOptimization.ConfigureCompression);
            services.AddResponseCaching(webOptimization.ConfigureCaching);
            return services;
        }
    }
}