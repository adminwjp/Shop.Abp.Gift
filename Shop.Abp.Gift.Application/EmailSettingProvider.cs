using Abp;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    /// <summary>
    /// https://aspnetboilerplate.com/Pages/Documents/Setting-Management
    /// EmailSettingProvider 已实现
    /// </summary>
    public class EmailSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            //qq email config
            return new[]
                     {
                       new SettingDefinition(EmailSettingNames.Smtp.Host, "smtp.qq.com", L("SmtpHost"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.Smtp.Port, "587", L("SmtpPort"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.Smtp.UserName, "973513569@qq.com", L("Username"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.Smtp.Password, "awalxnuvfcogbbjj", L("Password"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.Smtp.Domain, "", L("DomainName"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.Smtp.EnableSsl, "true", L("UseSSL"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.Smtp.UseDefaultCredentials, "false", L("UseDefaultCredentials"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.DefaultFromAddress, "973513569@qq.com", L("DefaultFromSenderEmailAddress"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                       new SettingDefinition(EmailSettingNames.DefaultFromDisplayName, "test email", L("DefaultFromSenderDisplayName"), scopes: SettingScopes.Application | SettingScopes.Tenant)
                   };
        }
        private static LocalizableString L(string name)
        {
            return new LocalizableString(name, AbpConsts.LocalizationSourceName);
        }
    }
}
