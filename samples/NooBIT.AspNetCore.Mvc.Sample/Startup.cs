using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NooBIT.AspNetCore.Mvc.Builders;
using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Middlewares;
using NooBIT.AspNetCore.Mvc.Optimizations;
using NooBIT.AspNetCore.Mvc.SimpleInjector;
using SimpleInjector;
using System;
using System.IO;

namespace NooBIT.AspNetCore.Mvc.Sample
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
                .UseKestrel(x => x.AddServerHeader = false) // never show where you host your stuff :)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .SuppressStatusMessages(false) // i want to see everything!
                .UseIISIntegration() // if hosting via iis <3
                .UseStartup<Startup>();

            var host = hostBuilder.Build();
            host.Run();
        }

        private readonly WebOptimization _webOptimizations;
        private Container _container;

        public Startup(IHostingEnvironment environment)
        {
            _webOptimizations = new WebOptimization(environment);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // feature folders make the project structure a bit more clear
            services.AddMvc().AddFeatureFolders().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddRouting(options => options.LowercaseUrls = true); // lowercase urls just look better :p
            services.AddWebOptimizations(_webOptimizations); // style and script bundling options aswell as caching and compression can be configured via IWebOptimization interface
            services.AddSimpleInjector(x => { x.Register<IServiceProvider>(() => services.BuildServiceProvider()); /* register your stuff here. basic wiring of controllers and stuff is already done internally */ }, out _container);
            services.AddAutoMapper(typeof(Startup).Assembly); // after adding automapper lets also validate all configs!
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment environment, IMapper mapper)
        {
            app.UseSimpleInjector(_container);

            if (environment.IsDevelopment())
            {
                _container.Verify();
                mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }

            app.UseWebOptimizations(_webOptimizations); // style and script bundling options aswell as caching and compression can be configured via IWebOptimization interface
            app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All }); // useful if behind a proxy e.g. nginx
            app.UseRecommendedSecurityHeaders(environment); // if development environment hsts is omitted!
            app.UseCustomHeaders(new HeaderPolicyBuilder().AddHeader(new MyCustomHeaderBuilder().WithValue("My Custom Value!"))); // custom headers can be added easily!
            app.UseMvcWithDefaultRoute(); // i prefer default routes as a fallback, but i really just use attributes
        }
    }
}