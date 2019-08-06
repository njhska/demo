using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace _01LoginAndOut.Controllers
{
    public class AccountController : ApiController
    {
        //重定向会在跳转之前写cookie吗
        [HttpGet]
        public HttpResponseMessage Login(string key)
        {
            var resp = new HttpResponseMessage();
            if (key == "wyj")
            {
                var cookie = new CookieHeaderValue("login_key", key);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                resp.StatusCode = HttpStatusCode.Redirect;
                resp.Headers.Add("location", indexPath);

            }
            else
            {
                resp.StatusCode = HttpStatusCode.NotFound;
            }
            return resp;
        }
        private readonly string indexPath = "/api/Home/Index";
    }
}
