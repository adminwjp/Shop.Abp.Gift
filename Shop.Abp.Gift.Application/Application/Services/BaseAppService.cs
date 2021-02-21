using Abp.Application.Services;
using Abp.Domain.Uow;
using Abp.ObjectMapping;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System.Collections.Generic;

namespace Shop.Application.Services
{
    /// <summary>
    /// 订单航运 服务 
    /// </summary>
    public class BaseAppService<Repository, Entity,CreateInput, UpdateInput,Input, Output>:ApplicationService
            where Repository :IBaseRepository<Entity>
            where Entity : BaseEntity
            where CreateInput:class
            where UpdateInput : class
            where Input : class
            where Output : class
    
    {
        protected Repository repository;
        public BaseAppService(Repository repository, IObjectMapper objectMapper)
        {
            this.repository = repository;
            this.ObjectMapper = objectMapper;
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual int Insert(CreateInput create)
        {
            Entity order = ObjectMapper.Map<Entity>(create);
            repository.Insert(order);
            return 1;
        }
        /// <summary>
        /// 修改 订单航运
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual int Update(UpdateInput update)
        {
            Entity order = ObjectMapper.Map<Entity>(update);
            //已删除 的不能 修改
            repository.Update(order);
            return 1;
        }
        public virtual void Delete(string id)
        {
            repository.Delete(id);
        }
        public virtual IList<Output> Find()
        {
            var res = repository.GetAllList();
            var result = ObjectMapper.Map<IList<Output>>(res);
            return result;
        }
        [UnitOfWork]
        public virtual void Delete(string[] ids)
        {
            repository.Delete(ids);
        }
        public virtual IList<Output> Find(Input entity)
        {
            Entity order = ObjectMapper.Map<Entity>(entity);
            var res = repository.Find(order);
            var result = ObjectMapper.Map<IList<Output>>(res);
            return result;
        }

        public virtual IList<Output> FindByPage(Input entity, int page = 1, int size = 10)
        {
            Entity order = ObjectMapper.Map<Entity>(entity);
            var res = repository.FindByPage(order, page, size);
            var result = ObjectMapper.Map<IList<Output>>(res);
            return result;
        }

        public virtual int Count(Input entity)
        {
            Entity order = ObjectMapper.Map<Entity>(entity);
            var res = repository.Count(order);
            return res;
        }
    }
}
