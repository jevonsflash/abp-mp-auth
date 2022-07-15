using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using WeChat.MiniProgram.Authentication.JwtBearer;
using WeChat.MiniProgram.Configuration;
using WeChat.MiniProgram.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using WeChat.MiniProgram.Authentication.External;
using GDMK.CAH.Authentication.WeChat;

namespace WeChat.MiniProgram
{
    [DependsOn(
         typeof(MiniProgramApplicationModule),
         typeof(MiniProgramEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule)
     )]
    public class MiniProgramWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MiniProgramWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MiniProgramConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(MiniProgramApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        private void ConfigureExternalAuth()
        {

            IocManager.Register<IExternalAuthConfiguration, ExternalAuthConfiguration>();
            var externalAuthConfiguration = IocManager.Resolve<IExternalAuthConfiguration>();
            var appId = _appConfiguration["WeChat:MiniProgram:AppId"];
            var appSecret = _appConfiguration["WeChat:MiniProgram:AppSecret"];
            externalAuthConfiguration.Providers.Add(new ExternalLoginProviderInfo(
                nameof(WeChatAuthProvider), appId, appSecret, typeof(WeChatAuthProvider))
                );
        }


        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MiniProgramWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MiniProgramWebCoreModule).Assembly);
        }
    }
}
