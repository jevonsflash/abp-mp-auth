using Newtonsoft.Json;

namespace WeChat.MiniProgram.Models
{
    public class MiniProgramCommonResponse : IMiniProgramResponse
    {
        [JsonProperty("errmsg")] public string ErrorMessage { get; set; }

        [JsonProperty("errcode")] public int ErrorCode { get; set; }
    }
}