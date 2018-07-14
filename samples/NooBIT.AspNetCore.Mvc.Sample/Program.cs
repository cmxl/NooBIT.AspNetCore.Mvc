using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace NooBIT.AspNetCore.Mvc.Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
                .UseKestrel(x => x.AddServerHeader = false)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .SuppressStatusMessages(false)
                .UseIISIntegration()
                .UseStartup<Startup>();

            var host = hostBuilder.Build();
            host.Run();
        }
    }
}