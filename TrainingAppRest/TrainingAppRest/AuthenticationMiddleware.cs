using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

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
                    return;
                }

            }
            else if (context.Request.Path.StartsWithSegments("/api/user"))
            {
                await _next.Invoke(context);
            }
            else
            {

                context.Response.StatusCode = 401;
                return;
            }
        }
    }
}
