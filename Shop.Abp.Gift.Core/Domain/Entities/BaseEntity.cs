using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    /// <summary>
    /// 基类 实体
    /// </summary>
    public class BaseEntity : IEntity<string>, IHasCreationTime, IHasModificationTime, IHasDeletionTime
    {
        /// <summary>
        /// 主键 ef Specified key was too long; max key length is 767 bytes
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// 创建 时间 ef  datetime(6) mysql 5.5 不支持 ; datetime mysql 支持
        /// </summary>
        public virtual DateTime CreationTime { get; set; }
        /// <summary>
        /// 修改 时间
        /// </summary>
      
        public virtual DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 软删除 标识
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        public virtual bool IsTransient()
        {
            return true;
        }
    }
}
