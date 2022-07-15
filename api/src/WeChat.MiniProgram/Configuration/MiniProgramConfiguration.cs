namespace WeChat.MiniProgram.Configuration
{
    public class MiniProgramConfiguration : IMiniProgramConfiguration
    {
        /// <summary>
        /// 消息加密的 Token。
        /// </summary>
        public string Token { get; set; }

        public string OpenAppId { get; set; }

        /// <summary>
        /// 微信公众号的 AppId。
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 微信公众号的 API Secret。
        /// </summary>
        public string AppSecret { get; set; }

        public string EncodingAesKey { get; set; }
    }
}