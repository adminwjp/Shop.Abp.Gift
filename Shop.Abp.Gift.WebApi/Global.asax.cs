using Abp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Utility.AspNet.Consul;
using Utility.Consul;

namespace Shop.Abp.Gift.Api
{
    public class WebApiApplication : AbpWebApplication<ShopGiftWebApiModule>
    {
        ConsulHelper consulHelper;
        protected override void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            base.Application_Start(sender, e);
            ConsulEntity consulEntity = new ConsulEntity() { Id=Guid.NewGuid().ToString("N")};
            consulEntity.IP = System.Configuration.ConfigurationManager.AppSettings["IP"];
            consulEntity.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            consulEntity.Name = System.Configuration.ConfigurationManager.AppSettings["Name"];
            consulEntity.ConsulIP = System.Configuration.ConfigurationManager.AppSettings["ConsulIP"];
            consulEntity.ConsulPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ConsulPort"]);
            consulEntity.Tags = System.Configuration.ConfigurationManager.AppSettings["Tags"].Split(',');
            consulHelper = new ConsulHelper(consulEntity);
           if(!consulHelper.IsStart)
            {
                consulHelper.Start();
            }
            //apb 返回结果 序列化 异常  GlobalConfiguration.Configuration.Formatters.XmlFormatter==null 具体异常信息不对
            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();//使用 json 默认 xml
        }
        protected override void Application_End(object sender, EventArgs e)
        {
            base.Application_End(sender, e);
            consulHelper?.Stop();
        }
    }
}
