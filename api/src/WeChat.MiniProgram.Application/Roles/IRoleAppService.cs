using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WeChat.MiniProgram.Roles.Dto;

namespace WeChat.MiniProgram.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
    }
}
