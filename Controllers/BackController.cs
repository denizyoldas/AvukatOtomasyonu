using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AvukatOtomasyonu.Controllers
{
    public class BackController : ApiController
    {
        public void Get()
        {
        }

        public IEnumerable<string> Get(int id) {
            return new string[] { "sasa", "sasa" };
        }
    }
}
