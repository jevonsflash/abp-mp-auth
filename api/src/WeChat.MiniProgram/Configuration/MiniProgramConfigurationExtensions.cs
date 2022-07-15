using Abp.Configuration.Startup;

namespace WeChat.MiniProgram.Configuration
{
    public static class MiniProgramConfigurationExtensions
    {
        /// <summary>
        ///     Used to configure ABP MiniProgram module.
        /// </summary>
        public static IMiniProgramConfiguration MiniProgram(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IMiniProgramConfiguration>();
        }
    }
}
