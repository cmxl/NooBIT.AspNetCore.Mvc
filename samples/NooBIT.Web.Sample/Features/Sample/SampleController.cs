using Microsoft.AspNetCore.Mvc;

namespace NooBIT.AspNetCore.Mvc.Sample.Features.Sample
{
    public class SampleController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            ViewData["Title"] = $"Hello from {nameof(SampleController)}!";
            return View();
        }
    }
}