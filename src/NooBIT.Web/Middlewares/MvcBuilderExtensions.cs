using System;
using Microsoft.Extensions.DependencyInjection;
using NooBIT.Web.FeatureFolders;

namespace NooBIT.Web.Middlewares
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddFeatureFolders(this IMvcBuilder services, FeatureFolderOptions options)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (options == null)
                throw new ArgumentException(nameof(options));

            var expander = new FeatureViewLocationExpander(options);

            services.AddMvcOptions(o => { o.Conventions.Add(new FeatureControllerModelConvention(options)); })
                .AddRazorOptions(o =>
                {
                    o.ViewLocationFormats.Clear();
                    o.ViewLocationFormats.Add(options.FeatureNamePlaceholder + @"\{0}.cshtml");
                    o.ViewLocationFormats.Add(options.FeatureFolderName + @"\Shared\{0}.cshtml");
                    o.ViewLocationFormats.Add(options.DefaultViewLocation);

                    o.ViewLocationExpanders.Add(expander);
                });

            return services;
        }

        public static IMvcBuilder AddFeatureFolders(this IMvcBuilder services)
        {
            return AddFeatureFolders(services, new FeatureFolderOptions());
        }
    }
}