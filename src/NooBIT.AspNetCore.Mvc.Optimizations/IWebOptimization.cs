using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.ResponseCompression;
using WebOptimizer;

namespace NooBIT.AspNetCore.Mvc.Optimizations
{
    public interface IWebOptimization
    {
        IHostingEnvironment Environment { get; }
        void ConfigurePipeline(IAssetPipeline pipeline);
        void ConfigureCompression(ResponseCompressionOptions options);
        void ConfigureCaching(ResponseCachingOptions options);
    }
}