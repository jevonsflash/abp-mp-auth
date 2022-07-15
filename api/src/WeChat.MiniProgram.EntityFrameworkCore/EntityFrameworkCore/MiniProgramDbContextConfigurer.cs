using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WeChat.MiniProgram.EntityFrameworkCore
{
    public static class MiniProgramDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MiniProgramDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MiniProgramDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
