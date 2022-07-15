using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeChat.MiniProgram.Authorization;

namespace WeChat.MiniProgram
{
    [DependsOn(
        typeof(MiniProgramCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MiniProgramApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MiniProgramAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MiniProgramApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
