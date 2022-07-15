using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.MiniProgram.MiniProgram
{

    public class WechatMiniProgramLoginTokenCacheItem
    {
        public string Status { get; set; }
        public string ProviderAccessCode { get; set; }
    }

}
