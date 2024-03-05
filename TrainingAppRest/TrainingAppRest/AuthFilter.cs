using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

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
                    throw new Exception("Bearer token not valid");
                }
            }
        }
    }
}
