using System.Threading.Tasks;
using Abp.Dependency;
using WeChat.MiniProgram.Configuration;
using WeChat.Common.Infrastructure.AccessToken;

namespace WeChat.MiniProgram.Infrastructure
{
    public class DefaultAccessTokenAccessor : IAccessTokenAccessor, ISingletonDependency
    {
        private readonly IMiniProgramConfiguration _configuration;

        private readonly IAccessTokenProvider _accessTokenProvider;

        public DefaultAccessTokenAccessor(
            IAccessTokenProvider accessTokenProvider,
            IMiniProgramConfiguration configuration)
        {
            _accessTokenProvider = accessTokenProvider;
            _configuration = configuration;
        }

        public virtual async Task<string> GetAccessTokenAsync()
        {

            return await _accessTokenProvider.GetAccessTokenAsync(_configuration.AppId, _configuration.AppSecret);
        }
    }
}