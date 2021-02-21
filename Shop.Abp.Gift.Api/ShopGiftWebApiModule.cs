#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
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


namespace Shop
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
#else
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Runtime.Caching;
using Abp.Runtime.Caching.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;
using System.Reflection;

namespace Shop
{

    /// <summary>
    /// doamin、数据访问层 ef 整合一起时 用这个
    /// </summary>
    [DependsOn(typeof(ShopGiftApplicationModule), typeof(AbpAspNetCoreModule))]
    public class ShopGiftWebApiModule : AbpModule
    {
        public override void PreInitialize()
        {

            Configuration.Modules.AbpAspNetCore().DefaultResponseCacheAttributeForAppServices = new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None };

            Configuration.IocManager.Resolve<IAbpAspNetCoreConfiguration>().EndpointConfiguration.Add(endpoints =>
            {
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(GetType().Assembly, "app");
        }
    }
}
#endif