using Abp.Configuration.Startup;

namespace WeChat.Common.Configuration
{
    public static class AbpWeChatConfigurationExtensions
    {
        /// <summary>
        ///     Used to configure ABP AbpWeChat module.
        /// </summary>
        public static IAbpWeChatConfiguration AbpWeChat(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpWeChatConfiguration>();
        }
    }
}
