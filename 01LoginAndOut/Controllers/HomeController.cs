using _01LoginAndOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _01LoginAndOut.Controllers
{
    [BlogMasterFilter]
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "ok";
        }
    }
}
