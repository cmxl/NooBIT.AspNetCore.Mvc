using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.ResponseCompression;
using WebOptimizer;

namespace NooBIT.Web.Performance
{
    public interface IWebOptimization
    {
        IHostingEnvironment Environment { get; }
        TimeSpan CacheDuration { get; }
        void ConfigurePipeline(IAssetPipeline pipeline);
        void ConfigureCompression(ResponseCompressionOptions options);
        void ConfigureCaching(ResponseCachingOptions options);
    }
}