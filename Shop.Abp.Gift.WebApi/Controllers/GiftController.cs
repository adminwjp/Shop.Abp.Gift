using Abp.Web.Models;
using Shop.Application.Services;
using Shop.Application.Services.Dtos;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Controllers
{
    [DontWrapResult]//abp 改变默认封装的返回格式
    public class GiftController : BaseController<GiftAppService, IGiftRepository, GiftEntity, CreateGiftInput, UpdateGiftInput,
       GiftInput, GiftOutput>
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