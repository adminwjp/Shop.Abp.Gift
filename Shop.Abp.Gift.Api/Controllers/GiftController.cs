#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
using Abp.Web.Models;
using Shop.Application.Services;
using Shop.Application.Services.Dtos;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System.Web.Http;

namespace Shop.Controllers
{
    [DontWrapResult]//abp 改变默认封装的返回格式
    public class GiftController : BaseController<GiftAppService, IGiftRepository, GiftEntity, CreateGiftInput, UpdateGiftInput,
        GiftInput,GiftOutput>
    {
        public GiftController(GiftAppService service) : base(service)
        {
            this.service = service;
        }
        [HttpGet]
        public string Test()
        {
            return "test";
        }
    }
}
#else
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services;
using Shop.Application.Services.Dtos;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Emails
{

    [Route("api/v{version:apiVersion}/admin/[controller]")]
    public class GiftController : BaseController<GiftAppService, IGiftRepository, GiftEntity, CreateGiftInput, UpdateGiftInput,
        GiftInput, GiftOutput>
    {
        public GiftController(GiftAppService service) : base(service)
        {
            this.service = service;
        }
    }
}

#endif