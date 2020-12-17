using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyBlog.Configuration;
using MyBlog.Web;

namespace MyBlog.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyBlogDbContextFactory : IDesignTimeDbContextFactory<MyBlogDbContext>
    {
        public MyBlogDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyBlogDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyBlogDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyBlogConsts.ConnectionStringName));

            return new MyBlogDbContext(builder.Options);
        }
    }
}
