using Newtonsoft.Json;
using WeChat.MiniProgram.Models;

namespace WeChat.MiniProgram.Services.Login
{
    /// <summary>
    /// 发送模板消息时，需要传递的请求参数。
    /// </summary>
    public class GetUserInfoRequest : MiniProgramCommonRequest
    {
        [JsonProperty("openid")]
        public string Openid { get; protected set; }
        public GetUserInfoRequest(string openid)
        {
            this.Openid = openid;
        }
    }
}