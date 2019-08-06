using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace _01LoginAndOut.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BlogMasterFilterAttribute : FilterAttribute, IAuthenticationFilter
    {
        
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var b = true;
            CookieHeaderValue cookie = context.Request.Headers.GetCookies("login_key").FirstOrDefault();
            if (cookie != null)
            {
                var key = cookie["login_key"].Value;
                if(key == "wyj")
                {
                    b = false;
                }
            }
            if(b)
                context.ErrorResult = new NotFoundResult(context.Request);
            return Task.FromResult<object>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }
    }
}