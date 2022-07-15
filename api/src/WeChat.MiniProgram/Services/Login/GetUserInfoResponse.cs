using Newtonsoft.Json;
using WeChat.MiniProgram.Models;

namespace WeChat.MiniProgram.Services.Login
{


    public class GetUserInfoResponse : IMiniProgramResponse
    {
        [JsonProperty("nickname")]

        public string NickName { get; set; }


        public string Sex { get; set; }


        public string City { get; set; }


        public string Province { get; set; }


        public string Country { get; set; }


        [JsonProperty("headimgurl")]
        public string HeadImgURL { get; set; }


        [JsonProperty("unionid")]
        public string UnionId { get; set; }
        public string ErrorMessage { get; set; }

        public int ErrorCode { get; set; }
    }

}