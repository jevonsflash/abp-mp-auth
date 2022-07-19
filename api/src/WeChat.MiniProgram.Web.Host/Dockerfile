#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 44311

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WeChat.MiniProgram.Web.Host/WeChat.MiniProgram.Web.Host.csproj", "src/WeChat.MiniProgram.Web.Host/"]
COPY ["src/WeChat.MiniProgram.Web.Core/WeChat.MiniProgram.Web.Core.csproj", "src/WeChat.MiniProgram.Web.Core/"]
COPY ["src/WeChat.MiniProgram.EntityFrameworkCore/WeChat.MiniProgram.EntityFrameworkCore.csproj", "src/WeChat.MiniProgram.EntityFrameworkCore/"]
COPY ["src/WeChat.MiniProgram.Core/WeChat.MiniProgram.Core.csproj", "src/WeChat.MiniProgram.Core/"]
COPY ["src/WeChat.MiniProgram/WeChat.MiniProgram.csproj", "src/WeChat.MiniProgram/"]
COPY ["src/WeChat.Common/WeChat.Common.csproj", "src/WeChat.Common/"]
COPY ["src/WeChat.MiniProgram.Application/WeChat.MiniProgram.Application.csproj", "src/WeChat.MiniProgram.Application/"]
RUN dotnet restore "src/WeChat.MiniProgram.Web.Host/WeChat.MiniProgram.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/WeChat.MiniProgram.Web.Host"
RUN dotnet build "WeChat.MiniProgram.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeChat.MiniProgram.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeChat.MiniProgram.Web.Host.dll"]