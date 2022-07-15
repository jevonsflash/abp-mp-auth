using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Common.Cache;

namespace WeChat.MiniProgram.MiniProgram
{

    public class WechatMiniProgramLoginTokenCache : MemoryCacheBase<WechatMiniProgramLoginTokenCacheItem>, ISingletonDependency
    {
        public WechatMiniProgramLoginTokenCache() : base(nameof(WechatMiniProgramLoginTokenCache))
        {

        }
    }

}
