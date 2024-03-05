using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace TrainingAppRest
{
    //Do not use
    public class AuthFilter : IAuthorizationFilter
    {
        private readonly IMemoryCache _cache;

        public AuthFilter(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                var bearer = authHeader.Substring("Bearer ".Length).Trim();
                var user = _cache.Get(bearer);
                if (user == null)
                {
                    throw new UnauthorizedAccessException("Bearer token not valid");
                }
            }
        }
    }
}
