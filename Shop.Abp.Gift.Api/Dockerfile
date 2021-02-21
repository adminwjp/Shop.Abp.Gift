#使用 publish 包 运行  项目多话 自动化操作 
#好像只能用小写 自动 转小写 
#docker build -t ShopAbpGiftApiv1 .
#docker run -t -d -p 80:5000 ShopAbpGiftApi:v1
#down 
#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /app

#linux docker It was not possible to find any compatible framework version
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
#端口不能一致 
EXPOSE 801


FROM base AS final
WORKDIR /app
COPY  . /app/out/ShopAbpGiftApi
WORKDIR /app/out/ShopAbpGiftApi 
ENTRYPOINT ["dotnet", "Shop.Abp.Gift.Api.dll"]