using Abp.Authorization;
using WeChat.MiniProgram.Authorization.Roles;
using WeChat.MiniProgram.Authorization.Users;

namespace WeChat.MiniProgram.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
