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
            //�ô��˱��� Ӧ���Ǿֲ�����
            //dotnet run ��������
            //dotnet xx.dll Production Prodution д����
            //���� �����ж� ɶ��˼ ������ ?
            DbConfig.Flag = DbFlag.MySql;
            LogHelper.Flag = LogFlag.File;
            ServiceConfig.Flag = ServiceFlag.Consul;
            //ʲô���� һֱ ���� ���� ?���� ��ô ������ 
            //���� vs ���� ��ô ������ 
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
