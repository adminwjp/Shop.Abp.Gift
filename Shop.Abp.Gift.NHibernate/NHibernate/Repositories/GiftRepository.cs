using Abp.NHibernate;
using NHibernate.Criterion;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.NHibernate.Repositories
{
    /// <summary>
    /// 礼物 仓库 
    /// </summary>
    public class GiftRepository : ShopRepositoryBase<GiftEntity>,IGiftRepository
    {
        public GiftRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }
        protected override string GetTable()
        {
            return GiftEntity.TableName;
        }
        protected override AbstractCriterion GetWhere(GiftEntity entity)
        {
            AbstractCriterion where =base.GetWhere(entity);
            if (!string.IsNullOrEmpty(entity.CreateAccount))
            {
                where |= Expression.Like("CreateAccount", entity.CreateAccount);
            }
            return where;
        }
    }
}
