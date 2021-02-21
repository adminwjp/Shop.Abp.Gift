using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using Serilog.Sinks.SystemConsole.Themes;
using Utility;
using Utility.AspNetCore;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //用错了变量 应该是局部变量
            //dotnet run 看不出来
            //dotnet xx.dll Production Prodution 写错了
            //调试 总是中断 啥意思 进不来 ?
            DbConfig.Flag = DbFlag.MySql;
            LogHelper.Flag = LogFlag.File;
            ServiceConfig.Flag = ServiceFlag.Consul;
            //什么玩意 一直 报错 缓存 ?调试 怎么 进不来 
            //重启 vs 调试 怎么 进不来 
            Console.Title = "Shop.Gift.Api";
            IConfigurationBuilder configurationBuilder = LogHelper.Builder();
            IConfiguration configuration = configurationBuilder.Build();
            //Unhandled exception. System.ArgumentNullException: Value cannot be null
            //config.AddConsul
            configuration = LogHelper.LogConfig(configuration);
            StartHelper.CreateWebHostBuilder<Startup>(configuration,args).Run();
        }

      
    }
}
