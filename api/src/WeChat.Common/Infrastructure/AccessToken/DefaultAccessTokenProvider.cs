using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using Abp.Dependency;
using WeChat.Common.Cache;

namespace WeChat.Common.Infrastructure.AccessToken
{
    public class DefaultAccessTokenProvider : IAccessTokenProvider, ISingletonDependency
    {
        private readonly AccessTokenCache _distributedCache;
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultAccessTokenProvider(AccessTokenCache distributedCache,
            IHttpClientFactory httpClientFactory)
        {
            _distributedCache = distributedCache;
            _httpClientFactory = httpClientFactory;
        }

        public virtual async Task<string> GetAccessTokenAsync(string appId, string appSecret)
        {
            var key = $"CurrentAccessToken:{appId}";
            var absoluteExpirationRelativeToNow = TimeSpan.FromMinutes(115);
            var absoluteExpiration = DateTime.Now + absoluteExpirationRelativeToNow;

            return await _distributedCache.GetAsync(key,
                  key => _GetAccessTokenAsync(appId, appSecret)
               ,
               absoluteExpireTime: absoluteExpiration);
        }

        private string _GetAccessTokenAsync(string appId, string appSecret)
        {
            var client = _httpClientFactory.CreateClient();

            var requestUrl = $"https://api.weixin.qq.com/cgi-bin/token?grant_type={GrantTypes.ClientCredential}&appid={appId}&secret={appSecret}";

            var resultStr = client.Send(new HttpRequestMessage(HttpMethod.Get, requestUrl))
                .Content.ReadAsStringAsync().Result;

            var resultJson = JObject.Parse(resultStr);

            var accessTokenObj = resultJson.SelectToken("$.access_token");

            if (accessTokenObj == null)
            {
                throw new NullReferenceException($"无法获取到 AccessToken，微信 API 返回的内容为：{resultStr}");
            }

            return accessTokenObj.Value<string>();
        }
    }
}