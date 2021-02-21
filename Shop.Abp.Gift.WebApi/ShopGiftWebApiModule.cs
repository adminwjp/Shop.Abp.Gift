using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.NHibernate;
using Abp.NHibernate.Filters;
using Abp.Web;
using Abp.Web.Localization;
using Abp.WebApi;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Configuration;
using System.Reflection;


namespace Shop.Abp.Gift.Api
{
    /// <summary>
    /// doamin、数据访问层 nhibernate 整合一起时 用这个
    /// </summary>
    [DependsOn(typeof(ShopGiftApplicationModule),typeof(AbpWebApiModule))]
    public class ShopGiftWebApiModule : AbpModule
    {

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebApi().SetNoCacheForAllResponses = true;

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //asp.net webapi
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(GetType().Assembly, "app")
                .Build();
        }
    }
}