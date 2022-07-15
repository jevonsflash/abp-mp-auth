using Newtonsoft.Json;

namespace WeChat.MiniProgram.Models
{
    public interface IMiniProgramResponse
    {
        [JsonProperty("errmsg")] string ErrorMessage { get; set; }

        [JsonProperty("errcode")] int ErrorCode { get; set; }
    }
}