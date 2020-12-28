using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.EntityFrameworkCore
{
    public static class MyBlogDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyBlogDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            var realConnectionString = Environment.GetEnvironmentVariable(connectionString,EnvironmentVariableTarget.Machine);
            builder.UseMySql(realConnectionString, new MySqlServerVersion(new Version(8, 0, 21)));
            //builder.UseSqlite(connectionString.Replace("=","=" + AppContext.BaseDirectory));
        }

        public static void Configure(DbContextOptionsBuilder<MyBlogDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 21)));
            //builder.UseSqlite(connection.ConnectionString.Replace("=", "=" + AppContext.BaseDirectory));
        }
    }
}
