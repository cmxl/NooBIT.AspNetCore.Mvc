using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NooBIT.Web.Sample.Controllers
{
    public class SampleController : Controller
    {
        [HttpGet("/")]
        [Produces("text/plain")]
        public async Task Index()
        {
            using (var sw = new StreamWriter(HttpContext.Response.Body))
            {
                await sw.WriteLineAsync($"Hello from {nameof(SampleController)}!");
                await sw.WriteLineAsync();
                foreach (var header in HttpContext.Response.Headers.OrderBy(x => x.Key))
                    await sw.WriteLineAsync(header.ToString());
            }
        }
    }
}