namespace WeChat.MiniProgram.Configuration
{
    public interface IMiniProgramConfiguration
    {
        /// <summary>
        /// 消息加密的 Token。
        /// </summary>
        string Token { get; set; }

        string OpenAppId { get; set; }

        /// <summary>
        /// 微信公众号的 AppId。
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// 微信公众号的 API Secret。
        /// </summary>
        string AppSecret { get; set; }

        string EncodingAesKey { get; set; }
    }
}