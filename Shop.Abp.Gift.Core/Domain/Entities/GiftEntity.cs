using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;


namespace Shop.Domain.Entities
{
	/// <summary>
	/// 礼物
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.Table("t_gift")]
	public class GiftEntity : BaseEntity
	{
		public const string TableName = "t_gift";
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
