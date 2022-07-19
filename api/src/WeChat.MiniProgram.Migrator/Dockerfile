#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WeChat.MiniProgram.Migrator/WeChat.MiniProgram.Migrator.csproj", "src/WeChat.MiniProgram.Migrator/"]
COPY ["src/WeChat.MiniProgram.EntityFrameworkCore/WeChat.MiniProgram.EntityFrameworkCore.csproj", "src/WeChat.MiniProgram.EntityFrameworkCore/"]
COPY ["src/WeChat.MiniProgram.Core/WeChat.MiniProgram.Core.csproj", "src/WeChat.MiniProgram.Core/"]
COPY ["src/WeChat.MiniProgram/WeChat.MiniProgram.csproj", "src/WeChat.MiniProgram/"]
COPY ["src/WeChat.Common/WeChat.Common.csproj", "src/WeChat.Common/"]
RUN dotnet restore "src/WeChat.MiniProgram.Migrator/WeChat.MiniProgram.Migrator.csproj"
COPY . .
WORKDIR "/src/src/WeChat.MiniProgram.Migrator"
RUN dotnet build "WeChat.MiniProgram.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeChat.MiniProgram.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeChat.MiniProgram.Migrator.dll"]