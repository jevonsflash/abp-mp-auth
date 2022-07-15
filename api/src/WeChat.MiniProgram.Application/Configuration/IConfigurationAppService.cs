using System.Threading.Tasks;
using WeChat.MiniProgram.Configuration.Dto;

namespace WeChat.MiniProgram.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
