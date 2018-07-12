using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using NooBIT.Web.Http;
using NooBIT.Web.Performance;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace NooBIT.Web.Middlewares
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

        public static IServiceCollection AddSimpleInjector(this IServiceCollection services, Action<Container> registerComponents, VerificationOption verificationOption = VerificationOption.VerifyAndDiagnose)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

            registerComponents?.Invoke(container);

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);

            container.Verify(verificationOption);

            return services;
        }

        public static IServiceCollection AddAutoMapperWithValidation(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            Mapper.AssertConfigurationIsValid();
            return services;
        }
    }
}