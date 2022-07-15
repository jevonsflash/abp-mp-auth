using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeChat.MiniProgram.EntityFrameworkCore;
using WeChat.MiniProgram.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace WeChat.MiniProgram.Web.Tests
{
    [DependsOn(
        typeof(MiniProgramWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MiniProgramWebTestModule : AbpModule
    {
        public MiniProgramWebTestModule(MiniProgramEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MiniProgramWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MiniProgramWebMvcModule).Assembly);
        }
    }
}