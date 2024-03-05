using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace TrainingAppRest
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;

        public AuthenticationMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {

            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                var bearer = authHeader.Substring("Bearer ".Length).Trim();
                var user = _cache.Get(bearer);
                if (user != null)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                }

            }
            else if (context.Request.Path.StartsWithSegments("/api/user"))
            {
                await _next.Invoke(context);
            }
            else
            {

                context.Response.StatusCode = 401;
            }
        }
    }
}
