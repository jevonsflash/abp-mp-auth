using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeChat.MiniProgram.Configuration;
using WeChat.MiniProgram.EntityFrameworkCore;
using WeChat.MiniProgram.Migrator.DependencyInjection;

namespace WeChat.MiniProgram.Migrator
{
    [DependsOn(typeof(MiniProgramEntityFrameworkModule))]
    public class MiniProgramMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MiniProgramMigratorModule(MiniProgramEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MiniProgramMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MiniProgramConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MiniProgramMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
