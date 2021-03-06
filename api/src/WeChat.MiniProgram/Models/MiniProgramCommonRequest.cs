using Newtonsoft.Json;

namespace WeChat.MiniProgram.Models
{
    public abstract class MiniProgramCommonRequest : IMiniProgramRequest
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}