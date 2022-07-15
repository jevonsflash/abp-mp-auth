using System.Threading.Tasks;
using Abp.Application.Services;
using WeChat.MiniProgram.Sessions.Dto;

namespace WeChat.MiniProgram.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
