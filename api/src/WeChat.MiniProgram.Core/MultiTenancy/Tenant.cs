using Abp.MultiTenancy;
using WeChat.MiniProgram.Authorization.Users;

namespace WeChat.MiniProgram.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
