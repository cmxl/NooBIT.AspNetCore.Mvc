using Microsoft.AspNetCore.Http;
using NooBIT.AspNetCore.Mvc.Http;
using System.Threading.Tasks;

namespace NooBIT.AspNetCore.Mvc.Middlewares
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HeaderPolicy _policy;

        public HeaderMiddleware(RequestDelegate next, HeaderPolicy policy)
        {
            _next = next;
            _policy = policy;
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Response.Headers;

            foreach (var headerValuePair in _policy.SetHeaders)
                headers[headerValuePair.Value.Name] = headerValuePair.Value.Value;

            foreach (var header in _policy.RemoveHeaders)
                headers.Remove(header);

            await _next(context);
        }
    }
}