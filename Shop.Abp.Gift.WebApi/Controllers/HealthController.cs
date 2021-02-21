using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Abp.Gift.Api.Controllers
{
    [DontWrapResult]//abp 改变默认封装的返回格式
    public class HealthController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("api/health")]
        public IHttpActionResult Get() => Ok("ok");
    }
}