using System.Net.Http;
using System.Threading.Tasks;
using WeChat.MiniProgram.Services.Login;
using WeChat.MiniProgram.Configuration;

namespace WeChat.MiniProgram.Services.Login
{
    /// <summary>
    /// 小程序登录服务。
    /// </summary>
    public class LoginService : CommonService
    {
        private readonly IMiniProgramConfiguration _configuration;

        public LoginService(IMiniProgramConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。
        /// </summary>
        /// <param name="jsCode">登录时获取的 code</param>
        /// <param name="grantType">授权类型，此处只需填写 authorization_code</param>
        public async Task<Code2SessionResponse> Code2SessionAsync(string jsCode, string grantType = "authorization_code")
        {
            return await Code2SessionAsync(_configuration.AppId, _configuration.AppSecret, jsCode, grantType);
        }

        /// <summary>
        /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。
        /// </summary>
        /// <param name="appId">小程序 appId</param>
        /// <param name="appSecret">小程序 appSecret</param>
        /// <param name="jsCode">登录时获取的 code</param>
        /// <param name="grantType">授权类型，此处只需填写 authorization_code</param>
        public Task<Code2SessionResponse> Code2SessionAsync(string appId, string appSecret, string jsCode, string grantType = "authorization_code")
        {
            const string targetUrl = "https://api.weixin.qq.com/sns/jscode2session?";

            var request = new Code2SessionRequest(appId, appSecret, jsCode, grantType);

            return WeChatMiniProgramApiRequester.RequestAsync<Code2SessionResponse>(targetUrl, HttpMethod.Get, request, false);
        }


        public Task<GetUserInfoResponse> GetUserInfoAsync(string openId)
        {
            const string targetUrl = "https://api.weixin.qq.com/sns/userinfo?";

            var request = new GetUserInfoRequest(openId);

            return WeChatMiniProgramApiRequester.RequestAsync<GetUserInfoResponse>(targetUrl, HttpMethod.Get, request, true);
        }
    }
}