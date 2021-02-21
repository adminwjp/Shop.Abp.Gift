using Abp.AutoMapper;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Application.Services.Dtos
{
    /// <summary>
    ///修改 礼物 实体
    /// </summary>
    [AutoMap(typeof(GiftEntity))]
    public class UpdateGiftInput:BaseGiftInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
    }
}
