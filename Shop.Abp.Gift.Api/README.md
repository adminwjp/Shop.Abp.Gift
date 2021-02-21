# shop.abp.gift.api
asp.net core 5.0 win 部署环境安装
https://dotnet.microsoft.com/download/dotnet/thank-you/runtime-aspnetcore-5.0.3-windows-hosting-bundle-installer
asp.net 
引用 添加不了 或 删除 不掉  手动 添加  或
如果 添加不了或 去掉 不了 删除 obj 文件 卸载 项目 再重新加载 就可以了

jenkins 这台计算机上缺少此项目引用的 NuGet 程序包。使用“NuGet 程序包还原”可下载这些程序包。有关更多信息，请参见 http://go.microsoft.com/fwlink/?LinkID=322105。缺少的文件是 
添加该文件 就可以了NuGet.config 
packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.1\build\net46\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props 缺少这个文件麻烦
直接修改 csproj工程文件

asp.net 怎么配置工程文件  格式 必须那样 目前支持 asp.net(新建一个 asp.net web 工程引用该类库 去掉  )  or asp.net core

nhibernate >5.3.2 有 bug 列名 跟 属性名不一致 条件查询 异常
abp 框架降级

example
name IdA  columnd id_a
错误 sql
IdA=?p0  and id_a=?p1
正确sql
id_a=?p1

dotnet Shop.Abp.Gift.Api.dll urls="http://*:6002"

asp.net 需要安装对应版本环境
