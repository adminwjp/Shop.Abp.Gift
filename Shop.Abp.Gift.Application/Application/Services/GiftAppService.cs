using Abp.ObjectMapping;
using Shop.Application.Services.Dtos;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;

namespace Shop.Application.Services
{
    /// <summary>
    /// 礼物 服务 
    /// </summary>
    public class GiftAppService : BaseAppService<IGiftRepository, GiftEntity, CreateGiftInput, UpdateGiftInput,
        GiftInput,GiftOutput >
    {
        public GiftAppService(IGiftRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper)
        {
        }

    }
}
