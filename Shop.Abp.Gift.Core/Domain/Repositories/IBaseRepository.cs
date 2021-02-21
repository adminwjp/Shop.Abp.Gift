using Abp.Domain.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IBaseRepository<Entity>:IRepository<Entity, string> 
        where Entity:BaseEntity
    {
        void Delete(string[] ids);
         IList<Entity> Find(Entity entity);
         IList<Entity> FindByPage(Entity entity, int page, int size);
         int Count(Entity entity);
    }
}
