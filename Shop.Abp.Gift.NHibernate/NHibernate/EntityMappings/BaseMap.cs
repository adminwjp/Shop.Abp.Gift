using Shop.Domain.Entities;
using Abp.NHibernate.EntityMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.NHibernate.EntityMappings
{
    public class BaseMap<Entity> : EntityMap<Entity, string>
        where Entity:BaseEntity
    {
        public BaseMap(string table) : base(table)
        {
            Id(x => x.Id).Column("id").Not.Nullable().Length(36);//主键
            //this.MapCreationTime();
            //this.MapLastModificationTime();
            //this.MapIsDeleted();
            //Map(x => x.DeletionTime).Nullable();
            this.Set();
            Map(x => x.CreationTime).Column("creation_time");
            Map(x => x.LastModificationTime).Column("last_modification_time");
            Map(x => x.DeletionTime).Column("deletion_time");
            Map(x => x.IsDeleted).Column("is_deleted");
        }

        protected virtual void Set()
        {

        }
    }
}
