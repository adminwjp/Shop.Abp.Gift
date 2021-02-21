using Abp.AutoMapper;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Application.Services.Dtos
{
    /// <summary>
    ///添加 礼物 实体
    /// </summary>
    [AutoMap(typeof(GiftEntity))]
    public class CreateGiftInput:BaseGiftInput
    {
    }
}
