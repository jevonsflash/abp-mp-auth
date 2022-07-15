using System.Threading.Tasks;

namespace WeChat.MiniProgram.Infrastructure
{
    public interface IAccessTokenAccessor
    {
        Task<string> GetAccessTokenAsync();
    }
}