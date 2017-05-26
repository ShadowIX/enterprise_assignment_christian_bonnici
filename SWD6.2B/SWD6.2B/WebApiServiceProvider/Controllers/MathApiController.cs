using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiServiceProvider.Controllers
{
    public class MathApiController : ApiController
    {
        //http://localhost:49700/api/mathapi
        [HttpGet]
        public string Sum()
        {
            return "hello world";
        }

        [HttpGet]
        //http://localhost:49700/api/mathapi/sum?x=1&y=1
        public int Sum(int x, int y)
        {
            return x + y;
        }
        [HttpGet]
        public object Subtract(int x, int y)
        {
            return new { ans = x - y };
        }
      
    }
}