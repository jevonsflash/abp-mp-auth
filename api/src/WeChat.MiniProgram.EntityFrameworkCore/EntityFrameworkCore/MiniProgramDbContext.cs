using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WeChat.MiniProgram.Authorization.Roles;
using WeChat.MiniProgram.Authorization.Users;
using WeChat.MiniProgram.MultiTenancy;

namespace WeChat.MiniProgram.EntityFrameworkCore
{
    public class MiniProgramDbContext : AbpZeroDbContext<Tenant, Role, User, MiniProgramDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MiniProgramDbContext(DbContextOptions<MiniProgramDbContext> options)
            : base(options)
        {
        }
    }
}
