using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.ResponseCompression;
using WebOptimizer;

namespace NooBIT.AspNetCore.Mvc.Optimizations
{
    public class WebOptimization : IWebOptimization
    {
        public WebOptimization(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public IHostingEnvironment Environment { get; }

        public virtual void ConfigurePipeline(IAssetPipeline pipeline)
        {
        }

        public virtual void ConfigureCompression(ResponseCompressionOptions options)
        {
            options.Providers.Add<GzipCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
        }

        public virtual void ConfigureCaching(ResponseCachingOptions options)
        {
        }
    }
}