﻿using System.Collections.Generic;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using Shop.Application.Services;
using Shop.Domain.Repositories;
using Utility.Enums;
using Utility.Response;

namespace Shop.Controllers
{
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [DontWrapResult]//abp 改变默认封装的返回格式
    public abstract class BaseController<Service, Repository, Entity, CreateInput, UpdateInput, Input, Output> : AbpApiController
     where Service : BaseAppService<Repository, Entity, CreateInput, UpdateInput, Input, Output>
     where Repository : IBaseRepository<Entity>
     where Entity : Shop.Domain.Entities.BaseEntity
     where CreateInput : class
     where UpdateInput : class
     where Input : class
     where Output : class

    {
        protected Service service;
        public BaseController(Service service)
        {
            this.service = service;
        }
        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        public IResponseApi Insert([FromBody] CreateInput create)
        {
            int res = service.Insert(create);
            return ResponseApi.Create(Language.Chinese, res > 0 ? Code.AddSuccess : Code.AddFail);
        }
        /// <summary>
        /// 修改 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        public IResponseApi Update([FromBody] UpdateInput update)
        {
            int res = service.Update(update);
            return ResponseApi.Create(Language.Chinese, res > 0 ? Code.ModifySuccess : Code.ModifyFail);
        }
        [HttpGet]
        public IResponseApi Delete(string id)
        {
            service.Delete(id);
            return ResponseApi.Create(Language.Chinese, Code.DeleteSuccess);
        }
        [HttpPost]
        public IResponseApi DeleteList([FromBody] Utility.Domain.Entities.DeleteEntity<string> ids)
        {
            service.Delete(ids.Ids);
            return ResponseApi.Create(Language.Chinese, Code.DeleteSuccess);
        }
        [HttpPost]
        public ResponseApi<IList<Output>> Find([FromBody] Input entity)
        {
            //Abp.WebApi.ExceptionHandling.AbpApiExceptionFilterAttribute pass 为何报错 
            var res = service.Find(entity);
            return ResponseApi<IList<Output>>.Create(Language.Chinese, Code.QuerySuccess).SetData(res);
        }
        [Route("findbypage/{page}/{size}")]
        [HttpPost]
        public ResponseApi<IList<Output>> FindByPage([FromBody] Input entity, int page = 1, int size = 10)
        {
            var res = service.FindByPage(entity, page, size);
            return ResponseApi<IList<Output>>.Create(Language.Chinese, Code.QuerySuccess).SetData(res);
        }
        [HttpPost]
        public int Count([FromBody] Input entity)
        {
            int res = service.Count(entity);
            return res;
        }
    }
}
