using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.NHibernate;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using System.Reflection;
using Utility;
using Utility.Config;

namespace Shop
{
    [DependsOn(typeof(AbpNHibernateModule), typeof(ShopGiftCoreModule))]
    public class ShopGiftDataModule: AbpModule
    {
        public override void PreInitialize()
        {
            DbConfig.Flag = DbFlag.MySql;
            //网上说 需要安装 System.Configuration.ConfigurationManager package 支持 web.config
            //net core 读取 不到  web.config  只能读取 app.config 多地址不能这样用了
            //动态读取配置
            string key = $"ShopGift/{DbConfig.Flag}ConnectionString";
            string connectionString = ConfigurationManager.ConnectionStrings[$"{DbConfig.Flag}ConnectionString"]?.ConnectionString; //获取不到  asp.net core 能获取到
            connectionString = ConfigManager.GetByConsul(key);
            connectionString = connectionString ?? throw new System.Exception("ConnectionString");
            switch (DbConfig.Flag)
            {
                case DbFlag.MySql:
                    Configuration.Modules.AbpNHibernate().FluentConfiguration
                        .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql().FormatSql().Raw("hbm2ddl.auto", "update"))
                       .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
                    break;
                case DbFlag.SqlServer:
                    Configuration.Modules.AbpNHibernate().FluentConfiguration
                        .Database(MsSqlCeConfiguration.Standard.ConnectionString(connectionString).ShowSql().FormatSql().Raw("hbm2ddl.auto", "update"))
                       .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
                    break;
                case DbFlag.Oracle:
                    Configuration.Modules.AbpNHibernate().FluentConfiguration
                        .Database(OracleManagedDataClientConfiguration.Oracle10.ConnectionString(connectionString).ShowSql().FormatSql().Raw("hbm2ddl.auto", "update"))
                        .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
                    break;
                case DbFlag.Postgre:
                    Configuration.Modules.AbpNHibernate().FluentConfiguration
                        .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString).ShowSql().FormatSql().Raw("hbm2ddl.auto", "update"))
                        .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
                    break;
                case DbFlag.Sqlite:
                    Configuration.Modules.AbpNHibernate().FluentConfiguration
                        .Database(SQLiteConfiguration.Standard.ConnectionString(connectionString).ShowSql().FormatSql().Raw("hbm2ddl.auto", "update"))
                        .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
                    break;
                default:
                    throw new System.NotSupportedException("not support database");
            }
       

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
