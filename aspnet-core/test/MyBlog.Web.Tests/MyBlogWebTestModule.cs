using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyBlog.EntityFrameworkCore;
using MyBlog.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyBlog.Web.Tests
{
    [DependsOn(
        typeof(MyBlogWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyBlogWebTestModule : AbpModule
    {
        public MyBlogWebTestModule(MyBlogEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyBlogWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyBlogWebMvcModule).Assembly);
        }
    }
}