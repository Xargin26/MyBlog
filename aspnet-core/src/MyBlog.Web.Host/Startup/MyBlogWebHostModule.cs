using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyBlog.Configuration;

namespace MyBlog.Web.Host.Startup
{
    [DependsOn(
       typeof(MyBlogWebCoreModule))]
    public class MyBlogWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyBlogWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyBlogWebHostModule).GetAssembly());
        }
    }
}
