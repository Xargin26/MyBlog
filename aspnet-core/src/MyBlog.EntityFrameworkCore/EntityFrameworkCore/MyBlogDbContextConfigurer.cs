using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.EntityFrameworkCore
{
    public static class MyBlogDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyBlogDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyBlogDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
