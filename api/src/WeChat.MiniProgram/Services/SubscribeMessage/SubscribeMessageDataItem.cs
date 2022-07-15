using Newtonsoft.Json;

namespace WeChat.MiniProgram.Services.SubscribeMessage
{
    public class SubscribeMessageDataItem
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}