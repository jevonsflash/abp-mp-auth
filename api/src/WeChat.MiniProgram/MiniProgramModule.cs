using Abp.Modules;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Abp.Reflection.Extensions;
using WeChat.MiniProgram.Configuration;
using WeChat.Common;
using WeChat.Common.Configuration;
using Microsoft.Extensions.Hosting;

namespace WeChat.MiniProgram
{
    [DependsOn(typeof(WeChatCommonModule))]
    public class MiniProgramModule : AbpModule
    {


        private readonly IConfigurationRoot _appConfiguration;
        public MiniProgramModule(IHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(
    typeof(MiniProgramModule).GetAssembly().GetDirectoryPathOrNull(), env.EnvironmentName, env.IsDevelopment()
);
        }
        public override void PreInitialize()
        {
            IocManager.Register<IMiniProgramConfiguration, MiniProgramConfiguration>();
            Configuration.Modules.MiniProgram().Token = _appConfiguration["WeChat:MiniProgram:Token"];
            Configuration.Modules.MiniProgram().OpenAppId = _appConfiguration["WeChat:MiniProgram:OpenAppId"];
            Configuration.Modules.MiniProgram().AppId = _appConfiguration["WeChat:MiniProgram:AppId"];
            Configuration.Modules.MiniProgram().AppSecret = _appConfiguration["WeChat:MiniProgram:AppSecret"];
            Configuration.Modules.MiniProgram().EncodingAesKey = _appConfiguration["WeChat:MiniProgram:EncodingAesKey"];
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}