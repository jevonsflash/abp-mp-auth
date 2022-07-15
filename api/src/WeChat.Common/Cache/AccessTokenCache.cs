using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace WeChat.Common.Cache
{
    public class AccessTokenCache : MemoryCacheBase<string>, ISingletonDependency
    {
        public AccessTokenCache() : base(nameof(AccessTokenCache))
        {

        }
    }
}
