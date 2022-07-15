using Microsoft.Extensions.DependencyInjection;
using Abp.Modules;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Abp.Reflection.Extensions;
using WeChat.Common.Configuration;
using Microsoft.Extensions.Hosting;

namespace WeChat.Common
{
    public class WeChatCommonModule : AbpModule
    {


        private readonly IConfigurationRoot _appConfiguration;
        public WeChatCommonModule(IHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(
    typeof(WeChatCommonModule).GetAssembly().GetDirectoryPathOrNull(), env.EnvironmentName, env.IsDevelopment()
);
        }
        public override void PreInitialize()
        {
            IocManager.Register<IAbpWeChatConfiguration, AbpWeChatConfiguration>();
            Configuration.Modules.AbpWeChat().Host = _appConfiguration["WeChat:Address"];
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}