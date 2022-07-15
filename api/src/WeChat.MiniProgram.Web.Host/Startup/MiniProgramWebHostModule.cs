using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeChat.MiniProgram.Configuration;

namespace WeChat.MiniProgram.Web.Host.Startup
{
    [DependsOn(
       typeof(MiniProgramWebCoreModule))]
    public class MiniProgramWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MiniProgramWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MiniProgramWebHostModule).GetAssembly());
        }
    }
}
