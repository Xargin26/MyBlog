using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyBlog.Authorization.Roles;
using MyBlog.Authorization.Users;
using MyBlog.MultiTenancy;

namespace MyBlog.EntityFrameworkCore
{
    public class MyBlogDbContext : AbpZeroDbContext<Tenant, Role, User, MyBlogDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options)
            : base(options)
        {
        }
    }
}
