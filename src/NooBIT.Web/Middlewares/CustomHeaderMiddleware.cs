using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NooBIT.Web.Security;

namespace NooBIT.Web.Middlewares
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HeaderPolicy _policy;

        public CustomHeaderMiddleware(RequestDelegate next, HeaderPolicy policy)
        {
            _next = next;
            _policy = policy;
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Response.Headers;

            foreach (var headerValuePair in _policy.SetHeaders)
                headers[headerValuePair.Key.Name] = headerValuePair.Value;

            foreach (var header in _policy.RemoveHeaders)
                headers.Remove(header.Name);

            await _next(context);
        }
    }
}