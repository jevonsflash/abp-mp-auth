using System.Collections.Generic;

namespace WeChat.MiniProgram.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
