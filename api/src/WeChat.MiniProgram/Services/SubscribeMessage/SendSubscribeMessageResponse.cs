using WeChat.MiniProgram.Models;

namespace WeChat.MiniProgram.Services.SubscribeMessage
{
    public class SendSubscribeMessageResponse : IMiniProgramResponse
    {
        public string ErrorMessage { get; set; }

        public int ErrorCode { get; set; }
    }
}