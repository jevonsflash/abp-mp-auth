using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.MiniProgram.Authentication.External;
using WeChat.MiniProgram.Services.Login;

namespace GDMK.CAH.Authentication.WeChat
{
    internal class WeChatAuthProvider : ExternalAuthProviderApiBase
    {
        private readonly LoginService loginService;

        public WeChatAuthProvider(LoginService loginService)
        {
            this.loginService = loginService;
        }

        public override async Task<ExternalAuthUserInfo> GetUserInfo(string accessCode)
        {

            var result = new ExternalAuthUserInfo();
            var weChatLoginResult = await loginService.Code2SessionAsync(accessCode);

            //小程序调用获取token接口 https://api.weixin.qq.com/cgi-bin/token 返回的token值无法用于网页授权接口！
            //tips：https://www.cnblogs.com/remon/p/6420418.html
            //var userInfo = await loginService.GetUserInfoAsync(weChatLoginResult.OpenId);

            var seed = Guid.NewGuid().ToString("N").Substring(0, 7);
            result.EmailAddress=$"{seed}@qq.com";
            result.Name = seed;
            result.Surname = "微信用户";
            result.ProviderKey = weChatLoginResult.OpenId;
            result.Provider = nameof(WeChatAuthProvider);

            return result;
        }
    }
}
