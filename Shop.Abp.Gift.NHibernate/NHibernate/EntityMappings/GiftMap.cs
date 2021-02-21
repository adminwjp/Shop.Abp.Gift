using Abp.NHibernate.EntityMappings;
using FluentNHibernate.Mapping;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.NHibernate.EntityMappings
{
    public class GiftMap:BaseMap<GiftEntity>
    {
        public GiftMap():base(GiftEntity.TableName)
        {
           
        }
        protected override void Set()
        {
            Map(x => x.UpdateAccount).Column("update_account").Length(20);
            Map(x => x.Status).Column("status").Length(20);
            Map(x => x.Picture).Column("picture").Length(255);
            Map(x => x.CreateAccount).Column("create_account").Length(20);
            Map(x => x.Price).Column("price");
            Map(x => x.Name).Column("name").Length(20);
        }
    }
}