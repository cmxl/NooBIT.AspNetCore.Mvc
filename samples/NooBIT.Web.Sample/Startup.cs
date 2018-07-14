using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NooBIT.AspNetCore.Mvc.AutoMapper;
using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Middlewares;
using NooBIT.AspNetCore.Mvc.Optimization;
using NooBIT.AspNetCore.Mvc.SimpleInjector;

namespace NooBIT.AspNetCore.Mvc.Sample
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        private readonly WebOptimization _webOptimizations;

        public Startup(IHostingEnvironment environment)
        {
            _environment = environment;
            _webOptimizations = new WebOptimization(environment);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddFeatureFolders().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddWebOptimizations(_webOptimizations);
            services.AddSimpleInjector(x => { /* register your stuff here */ });
            services.AddAutoMapperWithValidation(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWebOptimizations(_webOptimizations);
            app.UseForwardedHeaders(new ForwardedHeadersOptions {ForwardedHeaders = ForwardedHeaders.All});
            app.UseRecommendedSecurityHeaders();
            app.UseCustomHeaders(new HeaderPolicyBuilder().AddHeader(new Header("X-Custom-Header") {Value = "My Custom Value!"}));
            app.UseMvcWithDefaultRoute();
        }
    }
}