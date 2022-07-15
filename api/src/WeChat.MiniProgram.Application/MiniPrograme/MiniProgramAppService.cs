using Abp;
using Abp.Authorization;
using Abp.UI;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeChat.MiniProgram.MiniProgram;
using WeChat.MiniProgram.MiniPrograme.Dto;
using WeChat.MiniProgram.Net.MimeTypes;

namespace WeChat.MiniProgram.MiniPrograme
{

    [AbpAllowAnonymous]
    //[AbpAuthorize(PermissionNames.Pages_Wechat)]
    public class MiniProgramAppService : MiniProgramAppServiceBase
    {
        public static TimeSpan TokenCacheDuration = TimeSpan.FromMinutes(5);
        public static TimeSpan AuthCacheDuration = TimeSpan.FromMinutes(5);
        private readonly MiniProgramManager miniappManager;

        public MiniProgramAppService(MiniProgramManager miniappManager)
        {
            this.miniappManager=miniappManager;
        }
        [HttpGet]
        [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
        public async Task<IActionResult> GetACodeAsync(GetACodeAsyncInput input)
        {
            var mode = input.Mode;

            var result = await miniappManager.GetACodeAsync(input.Scene, input.Page, DateTimeOffset.Now.Add(TokenCacheDuration));

            if (mode == "stream")
            {
                var memoryStream = new System.IO.MemoryStream(result);

                return new FileStreamResult(memoryStream, MimeTypeNames.ImagePng)
                {
                    FileDownloadName = "Code"
                };
            }
            else if (mode == "content")
            {
                return new FileContentResult(result, MimeTypeNames.ImagePng);
            }
            else
            {
                throw new UserFriendlyException("请指定下载模式");
            }
        }

        [HttpGet]
        [AbpAllowAnonymous]
        public virtual async Task<WechatMiniProgramLoginTokenCacheItem> GetTokenAsync(string token)
        {
            var cacheItem = await miniappManager.GetTokenAsync(token);
            return cacheItem;
        }


        [AbpAllowAnonymous]
        public virtual async Task SetTokenAsync(SetTokenInput input)
        {
            await miniappManager.SetTokenAsync(input.Token, input.Status, input.ProviderAccessCode, input.IsCheckToken);
        }


        [AbpAllowAnonymous]
        public virtual async Task AccessAsync(ChangeStatusInput input)
        {
            await miniappManager.SetTokenAsync(input.Token, "ACCESSED", null, true, DateTimeOffset.Now.Add(AuthCacheDuration));
        }

        [AbpAllowAnonymous]
        public virtual async Task AuthenticateAsync(ChangeStatusInput input)
        {
            await miniappManager.SetTokenAsync(input.Token, "AUTHORIZED", input.ProviderAccessCode, true, DateTimeOffset.Now.Add(TimeSpan.FromMinutes(1)));
        }
    }
}
