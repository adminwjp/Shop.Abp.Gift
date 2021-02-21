using Abp.AutoMapper;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Application.Services.Dtos
{
	/// <summary>
	///查询 礼物 实体 返回 结果
	/// </summary>
	[AutoMap(typeof(GiftEntity))]
    public class GiftOutput:BasetGetAllDto
    {
		/// <summary>
		/// 更新账户
		/// </summary>
		public virtual string UpdateAccount { get; set; }
		/// <summary>
		/// 状态
		/// </summary>
		public virtual string Status { get; set; }
		/// <summary>
		/// 素材
		/// </summary>
		public virtual string Picture { get; set; }
		/// <summary>
		/// 创建账户
		/// </summary>
		public virtual string CreateAccount { get; set; }
		/// <summary>
		/// 礼物价格
		/// </summary>
		public virtual decimal? Price { get; set; }
		/// <summary>
		/// 礼物名称
		/// </summary>
		public virtual string Name { get; set; }
	}
}
