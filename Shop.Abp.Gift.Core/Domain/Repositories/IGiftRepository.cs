using Abp.Domain.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    /// <summary>
    /// 礼物 仓库 
    /// </summary>
    public interface IGiftRepository: IBaseRepository<GiftEntity>
    {
    }
}
