using Abp.Authorization;
using Abp.Domain.Services;
using Abp.UI;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeChat.MiniProgram.Services.ACode;

namespace WeChat.MiniProgram.MiniProgram
{
    public class MiniProgramManager : DomainService
    {

        private readonly ACodeService aCodeService;
        private readonly WechatMiniProgramLoginTokenCache wechatMiniProgramLoginTokenCache;

        public MiniProgramManager(ACodeService aCodeService,
            WechatMiniProgramLoginTokenCache wechatMiniProgramLoginTokenCache)
        {
            this.aCodeService=aCodeService;
            this.wechatMiniProgramLoginTokenCache=wechatMiniProgramLoginTokenCache;
        }
        public async Task<byte[]> GetACodeAsync(string token, string page, DateTimeOffset? absoluteExpireTime = null)
        {

            await wechatMiniProgramLoginTokenCache.SetAsync(token, new WechatMiniProgramLoginTokenCacheItem()
            {
                Status="CREATED",
            },
            absoluteExpireTime: absoluteExpireTime);


            var result = await aCodeService.GetUnlimitedACodeAsync(token, page);

            return result.BinaryData;
        }

        public virtual async Task<WechatMiniProgramLoginTokenCacheItem> GetTokenAsync(string token)
        {
            var cacheItem = await wechatMiniProgramLoginTokenCache.GetAsync(token, null);
            return cacheItem;
        }


        public virtual async Task SetTokenAsync(string token, string status, string providerAccessCode, bool isCheckToken = true, DateTimeOffset? absoluteExpireTime = null)
        {
            if (isCheckToken)
            {
                await CheckTokenAsync(token);

            }
            await wechatMiniProgramLoginTokenCache.SetAsync(token, new WechatMiniProgramLoginTokenCacheItem()
            {
                Status=status,
                ProviderAccessCode=providerAccessCode
            }, absoluteExpireTime: absoluteExpireTime);
        }



        public virtual async Task CheckTokenAsync(string token)
        {
            var cacheItem = await wechatMiniProgramLoginTokenCache.GetAsync(token, null);

            if (cacheItem == null)
            {
                throw new UserFriendlyException("WechatMiniProgramLoginInvalidToken",
            "微信小程序登录Token不合法");
            }
            else
            {
                if (cacheItem.Status=="AUTHORIZED")
                {
                    throw new UserFriendlyException("WechatMiniProgramLoginInvalidToken",
           "微信小程序登录Token已失效");
                }
            }
        }
    }


}
