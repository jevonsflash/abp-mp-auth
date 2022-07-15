using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WeChat.MiniProgram.Controllers
{
    public abstract class MiniProgramControllerBase: AbpController
    {
        protected MiniProgramControllerBase()
        {
            LocalizationSourceName = MiniProgramConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
