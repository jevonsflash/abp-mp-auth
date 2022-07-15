using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using WeChat.MiniProgram.Configuration.Dto;

namespace WeChat.MiniProgram.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MiniProgramAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
