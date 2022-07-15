using System.Threading.Tasks;
using Abp.Application.Services;
using WeChat.MiniProgram.Authorization.Accounts.Dto;

namespace WeChat.MiniProgram.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
