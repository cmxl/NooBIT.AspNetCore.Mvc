using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;

namespace NooBIT.AspNetCore.Mvc.SimpleInjector
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Initializes a Container with AsyncScopedLifestyle. Registers ActionContextAccessor, HttpContextAccessor, SimpleInjectorControllerActivator and SimpleInjectorViewComponentActivator.
        /// Enables CrossWiring and registers everything via registerComponents.
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="registerComponents">Custom registration Action for additional components</param>
        /// <param name="container">An instance of SimpleInjector's Container containing all provided registrations and basic ASP.NET registration.</param>
        /// <returns></returns>
        public static IServiceCollection AddSimpleInjector(this IServiceCollection services, Action<Container> registerComponents, out Container container)
        {
            container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

            registerComponents?.Invoke(container);

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);

            return services;
        }

        /// <summary>
        /// Calls RegisterMvcControllers and AutoCrossWireAspNetComponents on the container. Will also verify the container if verify == true.
        /// </summary>
        /// <param name="app">The IApplicationBuilder.</param>
        /// <param name="container">The SimpleInjector Container.</param>
        /// <param name="verify">If true, the container verifies itself via .Verify().</param>
        /// <returns></returns>
        public static IApplicationBuilder UseSimpleInjector(this IApplicationBuilder app, Container container, bool verify = true)
        {
            container.RegisterMvcControllers(app);
            container.AutoCrossWireAspNetComponents(app);

            if (verify)
                container.Verify();

            return app;
        }
    }
}