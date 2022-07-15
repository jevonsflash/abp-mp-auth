using Abp.Application.Services;
using WeChat.MiniProgram.MultiTenancy.Dto;

namespace WeChat.MiniProgram.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

