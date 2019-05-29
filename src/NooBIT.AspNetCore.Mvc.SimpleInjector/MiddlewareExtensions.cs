using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
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

            services.UseSimpleInjectorAspNetRequestScoping(container);
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope.
                options.AddAspNetCore()
                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    .AddControllerActivation()
                    .AddViewComponentActivation()
                    .AddPageModelActivation()
                    .AddTagHelperActivation();
            });

            registerComponents?.Invoke(container);

            return services;
        }
    }
}